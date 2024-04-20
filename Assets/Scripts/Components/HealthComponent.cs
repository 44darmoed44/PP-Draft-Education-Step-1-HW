using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] public int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private bool _isInvulnerable;

        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;

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
                Debug.Log(_health);
            }

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void IsInvulnerable()
        {
            _isInvulnerable = !_isInvulnerable;
        }
    }
}