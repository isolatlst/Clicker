using UnityEngine;

namespace Codebase.FX
{
    public class AmbientAudio : MonoBehaviour, IFxControlable
    {
        [SerializeField] private AudioSource _audioSource;

        public void On()
        {
            _audioSource.Play();
        }

        public void Off()
        {
            _audioSource.Stop();
        }
    }
}