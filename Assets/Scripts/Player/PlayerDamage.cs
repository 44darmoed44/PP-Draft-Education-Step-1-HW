using Scripts.Components.Health;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerDamage : PlayerBase
    {
        [SerializeField] private float _damageJumpScale;
        [SerializeField] private ParticleSystem _hitParticles;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private HealthComponent _healthComponent;
        private static readonly int HitKey = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _healthComponent = GetComponent<HealthComponent>();
        }

        private void Start()
        {
            _session.Data.Hp.Value = _healthComponent._health;
        }

        private void SpawnParticles()
        {
            var numCoinsToDispose = Mathf.Min(CoinsCount, 5);
            _session.Data.Inventory.Remove("Coin", numCoinsToDispose);

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(HitKey);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpScale);

            _session.Data.Hp.Value = _healthComponent._health;

            if (CoinsCount > 0)
            {
                SpawnParticles();
            }                    
        }
    }
}