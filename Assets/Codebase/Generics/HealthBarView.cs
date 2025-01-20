using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Generics
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarView : MonoBehaviour
    {
        private Slider _slider;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();    
        }

        public void UpdateHealthBar(int health, int maxHealth)
        {
            var healthPercent = (float)health / maxHealth;
            _slider.value = healthPercent;
        }
    }
}