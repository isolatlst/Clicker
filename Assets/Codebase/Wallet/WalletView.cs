using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Wallet;
using TMPro;
using UnityEngine;

namespace Codebase.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _viewText;

        private void Awake()
        {
            SignalBus.Subscribe<CoinsChangedSignal>(UpdateCoinsView);
        }

        private void UpdateCoinsView(CoinsChangedSignal signal)
        {
            _viewText.text = signal.Coins.ToString();
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<CoinsChangedSignal>(UpdateCoinsView);
        }
    }
}