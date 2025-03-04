using System;
using System.Collections.Generic;
using Codebase.Data.Level;
using Codebase.Data.Player;
using Codebase.Data.SaveSystem;
using Codebase.Data.Settings;
using Codebase.Data.Store;
using Codebase.FX;
using Codebase.Infrastructure.Signals.Attack;
using Codebase.Infrastructure.Signals.Enemy;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Settings;
using Codebase.Infrastructure.Signals.Store;
using Codebase.Infrastructure.Signals.Wallet;
using Zenject;

namespace Codebase.Infrastructure.Services
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
            SignalBus.Subscribe<UpdateLevelSignal>(SaveLevel);
            SignalBus.Subscribe<UpdateLevelsSignal>(SaveStore);
            SignalBus.Subscribe<CoinsChangedSignal>(SaveWallet);
            SignalBus.Subscribe<UpgradeAttackStatsSignal>(SaveAttack);
            SignalBus.Subscribe<UpdateFxSettingsSignal>(SaveFxSettings);
        }

        public void InitializeData()
        {
            LoadLevelStats();
            LoadStoreStats();
            LoadWalletStats();
            LoadAttackStats();
            LoadFxSettingsStats();
        }

        private void LoadAndFire<TStats, TSignal>(TStats defaultStats, Func<TStats, TSignal> createSignal)
            where TSignal : struct
            where TStats : class, new()
        {
            TStats stats = _saveRepository.Load(defaultStats);
            SignalBus.Fire(createSignal(stats));
        }

        private void SaveLevel(UpdateLevelSignal signal)
        {
            _saveRepository.Save(new LevelStats(signal.Index));
        }

        private void SaveStore(UpdateLevelsSignal signal)
        {
            _saveRepository.Save(new StoreStats(signal.DamageLevel, signal.PeriodicDamageLevel));
        }

        private void SaveWallet(CoinsChangedSignal signal)
        {
            _saveRepository.Save(new WalletStats(signal.Coins));
        }

        private void SaveAttack(UpgradeAttackStatsSignal signal)
        {
            _saveRepository.Save(new AttackStats(signal.Damage, signal.PeriodicDamage));
        }

        private void SaveFxSettings(UpdateFxSettingsSignal signal)
        {
            _saveRepository.Save(new SettingsConfig(signal.FxStatuses));
        }

        private void LoadLevelStats()
        {
            LoadAndFire(new LevelStats(), stats => new LoadLevelSignal(stats.Index));
        }

        private void LoadStoreStats()
        {
            LoadAndFire(new StoreStats(), stats => new LoadStoreSignal(stats.DamageLevel, stats.PeriodicDamageLevel));
        }

        private void LoadWalletStats()
        {
            LoadAndFire(new WalletStats(), stats => new LoadWalletSignal(stats.Coins));
        }

        private void LoadAttackStats()
        {
            LoadAndFire(new AttackStats(), stats => new LoadAttackSignal(stats.Damage, stats.PeriodicDamage));
        }

        private void LoadFxSettingsStats()
        {
            LoadAndFire(new SettingsConfig(), stats =>
                new LoadFxSettingsSignal(
                    new Dictionary<FxTypes, bool>()
                    {
                        { FxTypes.Ambient, stats.Fxes[FxTypes.Ambient] },
                        { FxTypes.ClickAudio, stats.Fxes[FxTypes.ClickAudio] },
                        { FxTypes.Haptic, stats.Fxes[FxTypes.Haptic] },
                    })
            );
        }

        public void Dispose()
        {
        }
    }
}