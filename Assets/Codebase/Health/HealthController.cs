namespace Codebase.Health
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

        private void OnHealthChanged(int health, bool isAnimated)
        {
            _healthView.UpdateHealthBar(health);
        }
        
        public void Dispose()
        {
            _healthModel.HealthChanged -= OnHealthChanged;
            _healthView.Reset();
        }
    }
}