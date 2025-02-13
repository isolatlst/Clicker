using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Enemy;
using Codebase.Wallet;
using UnityEngine;
using Zenject;

namespace Codebase.Player
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private SaveRepository _saveRepository;
        [SerializeField] private WalletView _walletView;
        // private WalletController _walletController;
        // private WalletStats _walletStats;
        // private Wallet.Wallet _wallet;
        // private EnemyFacade _enemy;
        //
        // #region Initialization
        //
        // [Inject] 
        // public void Construct(EnemyFacade enemyFacade)
        // {
        //     _enemy = enemyFacade;
        // }
        //
        // private void Awake()
        // {
        //     _walletStats = _saveRepository.Load(new WalletStats());
        // }
        //
        // private void Start()
        // {
        //     _wallet = new Wallet.Wallet();
        //     _walletController = new WalletController(_wallet, _walletView);
        //     _wallet.AddCoins(_walletStats.Coins);
        //
        //     _enemy.Health.Death += OnEnemyDeath;
        // }
        //
        // #endregion
        //
        // private void OnEnemyDeath()
        // {
        //     _wallet.AddCoins(_enemy.CoinsPerDeath);
        //     _walletStats.Coins += _enemy.CoinsPerDeath;
        // }
        //
        // //TODO поменять перед билдом на закоменченое
        // private void OnDestroy()
        // {
        //     _saveRepository.Save(_walletStats);
        //     _enemy.Health.Death -= OnEnemyDeath;
        // }
        // // private void OnApplicationPause(bool isPaused) 
        // // {
        // //     if (isPaused)
        // //     {
        // //         _saveRepository.Save(_walletStats);
        // //         _enemy.Health.Death -= OnEnemyDeath;
        // //     }
        // // }
    }
}