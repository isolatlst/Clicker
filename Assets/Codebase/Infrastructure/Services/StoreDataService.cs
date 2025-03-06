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
        private Dictionary<BoostType, int> _boostLevels = new();
        private Dictionary<BoostType, List<StoreItemConfig>> _boostStats = new();

        public void Initialize()
        {
            var data = Resources.Load<StoreData>("Store/HandledStoreConfig");
            _boostStats.Add(BoostType.Damage, data.DamagePrice);
            _boostStats.Add(BoostType.PeriodicDamage, data.PeriodicDamagePrice);
            
            SignalBus.Subscribe<LoadStoreSignal>(LoadStore);
            SignalBus.Subscribe<SuccessfulBuySignal>(UpdateLevels);
        }

        private void LoadStore(LoadStoreSignal signal)
        {
            _boostLevels.Add(BoostType.Damage, signal.DamageLevel);
            _boostLevels.Add(BoostType.PeriodicDamage, signal.PeriodicDamageLevel);

            SignalBus.Unsubscribe<LoadStoreSignal>(LoadStore);
        }

        private void UpdateLevels(SuccessfulBuySignal signal)
        {
            _boostLevels[signal.Type]++;

            SignalBus.Fire(new UpdateBoostLevelsSignal(
                _boostLevels[BoostType.Damage],
                _boostLevels[BoostType.PeriodicDamage]));
        }

        public StoreItemConfig GetStoreItemConfig(BoostType type)
        {
            var configs = _boostStats[type];

            if (_boostLevels[type] >= configs.Count - 1)
                _boostLevels[type] = 0;

            return configs[_boostLevels[type]];
        }
    }
}