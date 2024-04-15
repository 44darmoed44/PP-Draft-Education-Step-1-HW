using UnityEngine;

namespace Scripts
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private float _damageJumpScale;
        [SerializeField] private bool _isInvulnerable;
        [SerializeField] private ParticleSystem _hitParticles;
        [SerializeField] private GameSession _gameSession;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private static readonly int HitKey = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void SpawnParticles()
        {
            var numCoinsToDispose = Mathf.Min(_gameSession._totalCoinsValue, 5);
            _gameSession._totalCoinsValue -= numCoinsToDispose;

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

                if (_gameSession._totalCoinsValue > 0)
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