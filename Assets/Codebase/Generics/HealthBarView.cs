using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Generics
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarView : MonoBehaviour
    {
        private Slider _slider;
        private int _maxHealth;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void UpdateHealthBar(int health)
        {
            if (health > _maxHealth)
                _maxHealth = health;

            var healthPercent = (float)health / _maxHealth;
            _slider.value = healthPercent;
        }
    }
}