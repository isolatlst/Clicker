using System.Collections.Generic;
using Codebase.Core.Store;
using Codebase.Data.Store;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Store;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Services
{
    public class StoreDataService : IInitializable
    {
        private StoreData _storeData;
        private int _damageLevel;
        private int _periodicDamageLevel;

        public void Initialize()
        {
            _storeData = Resources.Load<StoreData>("Store/HandledStoreConfig");
            SignalBus.Subscribe<LoadStoreSignal>(LoadStore);
            SignalBus.Subscribe<SuccessfulBuySignal>(UpdateLevels);
        }

        private void LoadStore(LoadStoreSignal signal)
        {
            _damageLevel = signal.DamageLevel;
            _periodicDamageLevel = signal.PeriodicDamageLevel;
            SignalBus.Unsubscribe<LoadStoreSignal>(LoadStore);
        }

        private void UpdateLevels(SuccessfulBuySignal signal)
        {
            if (signal.Type == BoostName.Damage)
                _damageLevel++;

            if (signal.Type == BoostName.PeriodicDamage)
                _periodicDamageLevel++;
        }
        
        private ref int GetLevel(BoostName name) => ref name == BoostName.Damage ? ref _damageLevel : ref _periodicDamageLevel;
        private List<StoreItemConfig> GetPriceList(BoostName name) => name == BoostName.Damage ? _storeData.DamagePrice : _storeData.PeriodicDamagePrice;

        public StoreItemConfig GetStoreItemConfig(BoostName name)
        {
            ref int level = ref GetLevel(name);
            var priceList = GetPriceList(name);

            if (level >= priceList.Count - 1) 
                level = 0;

            SignalBus.Fire(new LoadStoreSignal(_damageLevel, _periodicDamageLevel));

            return priceList[level];
        }
    }
}