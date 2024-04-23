using Scripts.Components;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Scripts.Creatures
{
    public class Creature : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private bool _invertScale;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpVelocity;
        [SerializeField] private float _damageVelocity;
        [SerializeField] private int _damage;

        [Header("Checkers")]
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] protected SpawnComponent _particles;

        protected Rigidbody2D _rigidbody;
        protected Vector2 Direction;
        protected Animator _animator;
        private bool _isGrounded;
        private bool _isJumping;

        
        private static readonly int IsGroundKey = Animator.StringToHash("isGrounded");
        private static readonly int IsRunningKey = Animator.StringToHash("isRunning");
        private static readonly int VetricalVelocityKey = Animator.StringToHash("vetricalVelocity");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int AttackKey = Animator.StringToHash("Attack");


        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>(); 
            _animator = GetComponent<Animator>();           
        }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        public void SpawnRunParticles()
        {
            _particles.Spawn("Run");
        }

        protected virtual void Update()
        {
            _isGrounded = _groundCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            var xVelocity = Direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetBool(IsRunningKey, Direction.x != 0);
            _animator.SetFloat(VetricalVelocityKey, _rigidbody.velocity.y);

            UpdateSpriteDirection();
        }

        private void UpdateSpriteDirection()
        {
            var multiplier = _invertScale ? -1 : 1;
            if (Direction.x > 0f)
            {
                transform.localScale = new Vector3(multiplier, 1, 1);
            }
            else if (Direction.x < 0f)
            {
                transform.localScale = new Vector3(-1 * multiplier, 1, 1);
            }
        }

        protected virtual float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = Direction.y > 0;

            if (_isGrounded)
            {
                _isJumping = false;
            }

            if (isJumpPressing)
            {
                _isJumping = true;
                
                var isFalling = _rigidbody.velocity.y <= 0.01f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (_rigidbody.velocity.y > 0 && _isJumping)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {
            if (_isGrounded)
            {
                yVelocity = _jumpVelocity;
                _particles.Spawn("Jump");
            }

            return yVelocity;
        }

        public virtual void TakeDamage()
        {
            _isJumping = false;
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageVelocity);   
        }

        public virtual void Attack()
        {
            _animator.SetTrigger(AttackKey);
        }

        public void OnDoAttack()
        {
            var gos = _attackRange.GetObjectsInRange();
            foreach (var go in gos)
            {
                var hp = go.GetComponent<HealthComponent>();
                if (hp != null && go.CompareTag("Player"))
                {
                    hp.ModifyHealth(-_damage);
                }
            }
        }
    }
}