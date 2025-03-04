using Codebase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.FX
{
    public class ClickAudioResponse : MonoBehaviour, IFxControlable
    {
        [SerializeField] private AudioSource _audioSource;
        private IInputHandler _inputHandler;
        private bool _isShouldPlay;

        [Inject]
        public void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void Awake()
        {
            _inputHandler.Clicked += PlayEffect;
        }

        public void On()
        {
            _isShouldPlay = true;
        }

        private void PlayEffect()
        {
            if (_isShouldPlay)
            {
                _audioSource.Stop();
                _audioSource.Play();
            }
        }

        public void Off()
        {
            _isShouldPlay = false;
        }

        private void OnDestroy()
        {
            _inputHandler.Clicked -= PlayEffect;
        }
    }
}