using Scripts.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] public int _health;
        [SerializeField] public UnityEvent _onDamage;
        [SerializeField] private bool _isInvulnerable;

        [SerializeField] public UnityEvent _onHeal;
        [SerializeField] public UnityEvent _onDie;

        public void ModifyHealth(int changeHPValue)
        {
            if (!_isInvulnerable)
            {
                _health += changeHPValue;
                
                if (changeHPValue < 0)
                {
                    _onDamage?.Invoke();
                }
            }

            if (changeHPValue > 0)
            {
                _onHeal?.Invoke();
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void IsInvulnerbale()
        {
            _isInvulnerable = !_isInvulnerable;
        }
    }
}