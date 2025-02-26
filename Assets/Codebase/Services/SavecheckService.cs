using System;
using Codebase.Data.Level;
using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.Attack;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Wallet;
using Zenject;

namespace Codebase.Services
{
    public class SavecheckService : IInitializable, IDisposable
    {
        private readonly SaveRepository _saveRepository;

        public SavecheckService(SaveRepository saveRepository)
        {
            _saveRepository = saveRepository;
        }

        public void Initialize()
        {
            SignalBus.Subscribe<CoinsChangedSignal>(SaveWallet);
            SignalBus.Subscribe<UpgradeAttackStatsSignal>(SaveAttack);
            SignalBus.Subscribe<UpdateLevelSignal>(SaveLevel);

            LoadLevelStats();
            LoadWalletStats();
            LoadAttackStats();
        }

        private void SaveLevel(UpdateLevelSignal signal)
        {
            _saveRepository.Save(new LevelStats(signal.Index));
        }

        private void SaveWallet(CoinsChangedSignal signal)
        {
            _saveRepository.Save(new WalletStats(signal.Coins));
        }

        private void SaveAttack(UpgradeAttackStatsSignal signal)
        {
            _saveRepository.Save(new AttackStats(signal.Damage, signal.PeriodicDamage));
        }

        private void LoadLevelStats()
        {
            LevelStats stats = _saveRepository.Load(new LevelStats());

            SignalBus.Fire(
                new LoadLevelSignal(stats.Index)
            );
        }

        private void LoadWalletStats()
        {
            WalletStats stats = _saveRepository.Load(new WalletStats());

            SignalBus.Fire(
                new LoadWalletSignal(stats.Coins)
            );
        }

        private void LoadAttackStats()
        {
            AttackStats stats = _saveRepository.Load(new AttackStats());

            SignalBus.Fire(
                new LoadAttackSignal(stats.Damage, stats.PeriodicDamage)
            );
        }

        public void Dispose()
        {
        }
    }
}