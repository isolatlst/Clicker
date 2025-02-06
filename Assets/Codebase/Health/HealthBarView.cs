using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarView : MonoBehaviour
    {
        private Slider _viewSlider;

        private void Awake()
        {
            _viewSlider = GetComponent<Slider>();
        }

        public void Reset()
        {
            _viewSlider.maxValue = 1;
        }

        public void UpdateHealthBar(int health)
        {
            if (health > _viewSlider.maxValue)
                _viewSlider.maxValue = health; // норм? возможно, нужен метод инициализации
            
            _viewSlider.value = health;
        }
    }
}