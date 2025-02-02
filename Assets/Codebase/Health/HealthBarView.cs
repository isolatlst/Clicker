using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarView : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void Reset()
        {
            _slider.maxValue = 1;
        }

        public void UpdateHealthBar(int health)
        {
            if (health > _slider.maxValue)
                _slider.maxValue = health + 1; // норм?
            
            _slider.value = health;
        }
    }
}