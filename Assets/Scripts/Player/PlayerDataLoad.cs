using Scripts.Components.Health;

namespace Scripts.Player
{
    public class PlayerDataLoad : PlayerBase
    {
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
        }

        protected override void Start()
        {
            _healthComponent._health = _session.Data.Hp.Value;
        }
    }
}