using TMPro;
using UnityEngine;

namespace Codebase.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _viewText;
        
        public void UpdateCoinsView(int amount)
        {
            _viewText.text = amount.ToString();
        }
    }
}