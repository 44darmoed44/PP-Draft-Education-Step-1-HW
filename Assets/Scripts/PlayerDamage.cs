using UnityEngine;

namespace Scripts
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private float _damageJumpScale;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private static readonly int HitKey = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(HitKey);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpScale);
        }
    }
}