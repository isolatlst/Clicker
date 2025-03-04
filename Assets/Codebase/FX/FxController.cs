using System.Collections.Generic;
using Codebase.Infrastructure;
using Codebase.Infrastructure.Signals.SaveSystemSignals;
using Codebase.Infrastructure.Signals.Settings;
using UnityEngine;

namespace Codebase.FX
{
    public class FxController : MonoBehaviour
    {
        [SerializeField] private AmbientAudio _ambient;
        [SerializeField] private ClickAudioResponse _clickResponse;
        [SerializeField] private Haptic _haptic;
        private Dictionary<FxTypes, (IFxControlable, bool)> _fxControlables = new();

        private void Awake()
        {
            SignalBus.Subscribe<LoadFxSettingsSignal>(LoadFxSettings);
            SignalBus.Subscribe<SwapFxStatusSignal>(SwapFxStatus);
        }

        private void LoadFxSettings(LoadFxSettingsSignal signal)
        {
            _fxControlables.Add(FxTypes.Ambient, (_ambient, signal.FxStatuses[FxTypes.Ambient]));
            _fxControlables.Add(FxTypes.ClickAudio, (_clickResponse, signal.FxStatuses[FxTypes.ClickAudio]));
            _fxControlables.Add(FxTypes.Haptic, (_haptic, signal.FxStatuses[FxTypes.Haptic]));

            foreach (var fx in signal.FxStatuses)
            {
                if (fx.Value == true)
                    _fxControlables[fx.Key].Item1.On();
            }

            SignalBus.Unsubscribe<LoadFxSettingsSignal>(LoadFxSettings);
        }

        private void SwapFxStatus(SwapFxStatusSignal signal)
        {
            var fx = _fxControlables[signal.Type];
            _fxControlables[signal.Type] = (_fxControlables[signal.Type].Item1, signal.IsEnabled);

            if (signal.IsEnabled)
                fx.Item1.On();
            else
                fx.Item1.Off();

            SignalBus.Fire(new UpdateFxSettingsSignal(new Dictionary<FxTypes, bool>()
            {
                { FxTypes.Ambient, _fxControlables[FxTypes.Ambient].Item2 },
                { FxTypes.ClickAudio, _fxControlables[FxTypes.ClickAudio].Item2 },
                { FxTypes.Haptic, _fxControlables[FxTypes.Haptic].Item2 }
            }));
        }

        private void OnDestroy()
        {
            SignalBus.Unsubscribe<SwapFxStatusSignal>(SwapFxStatus);
        }
    }
}