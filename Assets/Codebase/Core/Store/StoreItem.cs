using Codebase.Data.Store;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Store;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.Core.Store
{
    public class StoreItem : MonoBehaviour
    {
        [SerializeField] private BoostType _type;
        [SerializeField] private TMP_Text _bonusText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _priceText;
        private StoreDataService _storeDataService;
        private int _price;
        private int _bonus;

        [Inject]
        public void Construct(StoreDataService storeDataService)
        {
            _storeDataService = storeDataService;
        }

        private void Awake()
        {
            SignalBus.Subscribe<LoadStoreSignal>(LoadConfig);
            SignalBus.Subscribe<SuccessfulBuySignal>(OnSuccessfulBuy);
        }

        private void LoadConfig(LoadStoreSignal signal)
        {
            UpdateConfig();
            SignalBus.Unsubscribe<LoadStoreSignal>(LoadConfig);
        }

        private void OnSuccessfulBuy(SuccessfulBuySignal signal)
        {
            if (signal.Type == _type)
                UpdateConfig();
        }

        private void UpdateConfig()
        {
            StoreItemConfig storeItemConfig = _storeDataService.GetStoreItemConfig(_type);

            _price = storeItemConfig.Price;
            _bonus = storeItemConfig.Bonus;
            _bonusText.text = "+" + _bonus;
            _levelText.text = storeItemConfig.Level + " lvl";
            _priceText.text = _price.ToString();
        }

        public void Buy()
        {
            SignalBus.Fire(new TryBuySignal(_type, _price, _bonus));
        }
    }
}