namespace Codebase.Generics
{
    public class HealthController
    {
        private readonly Health _healthModel;
        private readonly HealthBarView _healthView;

        public HealthController(Health healthModel, HealthBarView healthView)
        {
            _healthModel = healthModel;
            _healthView = healthView;
            
            _healthModel.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int health, int maxHealth)
        {
            _healthView.UpdateHealthBar(health, maxHealth);
        }
        
        public void Dispose()
        {
            _healthModel.HealthChanged -= OnHealthChanged;
        }
    }
}