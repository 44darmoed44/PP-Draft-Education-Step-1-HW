using UnityEngine;

namespace Scripts
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private float _damageJumpScale;
        [SerializeField] private bool _isInvulnerable;
        [SerializeField] private ParticleSystem _hitParticles;
        [SerializeField] private PlayerCoins _playerCoins;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private static readonly int HitKey = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerCoins = GetComponent<PlayerCoins>();
        }

        private void SpawnParticles()
        {
            var totalCoins = _playerCoins.GetTotalCoinsValue();
            var numCoinsToDispose = Mathf.Min(totalCoins, 5);
            _playerCoins.SetTotalCoinsValue(totalCoins-numCoinsToDispose);

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void TakeDamage()
        {
            if (!_isInvulnerable)
            {
                _animator.SetTrigger(HitKey);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpScale);

                if (_playerCoins.GetTotalCoinsValue() > 0)
                {
                    SpawnParticles();
                }                    
            }
        }

        public void IsInvulnerable()
        {
            _isInvulnerable = !_isInvulnerable;
        }
    }
}