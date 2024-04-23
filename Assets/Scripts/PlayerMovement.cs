using Scripts.Components;
using Scripts.Model;
using UnityEditor.Animations;
using UnityEngine;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpScale;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private bool _isSpawnFallParticle;
        [SerializeField] private bool _allowDoubleJump;
        
        [SerializeField] private SpawnComponent _particlesSpawner;
        [SerializeField] private SpawnComponent _attackParticlesSpawner;

        [SerializeField] private LayerCheck _groundCheck;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        private float _lastVelocityY;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private PlayerInputReader _playerInputReader;
        private GameSession _session;

        private static readonly int isGroundKey = Animator.StringToHash("isGrounded");
        private static readonly int isRunningKey = Animator.StringToHash("isRunning");
        private static readonly int allowDoubleJumpKey = Animator.StringToHash("allowDoubleJump");
        private static readonly int vetricalVelocityKey = Animator.StringToHash("vetricalVelocity");


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _playerInputReader = GetComponent<PlayerInputReader>();
            _session = FindObjectOfType<GameSession>();
            UpdatePlayerWeapon();
        }


        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }


        public void SaySomething()
        {
            Debug.Log("Something");
        }


        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
        }


        private void UpdateAnimation()
        {
            _animator.SetFloat(vetricalVelocityKey, _rigidbody.velocity.y);
            _animator.SetBool(isGroundKey, _isGrounded);
            _animator.SetBool(isRunningKey, _direction.x != 0);

            if(_direction.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (_direction.x  < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }


        private float CalculateYVelocity()
        {   
            var yVelocity = _rigidbody.velocity.y;
            var isJumping = _direction.y > 0;

            if(_isGrounded) _allowDoubleJump = true;

            if (isJumping)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        
        private float CalculateJumpVelocity(float yVeocity) 
        {
            var isFalling = _rigidbody.velocity.y < 1;
            if(!isFalling) return yVeocity;

            if(_isGrounded)
            {
                yVeocity += _jumpScale;
            }
            else if (_allowDoubleJump)
            {
                yVeocity = _jumpScale;
                _animator.SetTrigger(allowDoubleJumpKey);
                _allowDoubleJump = false;
            }

            return yVeocity;
        }


        public void FootStepsParticlesSpawner()
        {
            _particlesSpawner.Spawn("FootStepsParticle");
        }


        public void JumpParticlesSpawner()
        {
            _particlesSpawner.Spawn("JumpParticle");
        }


        private void FallParticleSpawner()
        {
            _particlesSpawner.Spawn("FallParticle");
        }

        private void AttackParticleSpawner()
        {
            _attackParticlesSpawner.Spawn("SwordAttackParticle");
        }

        public void ArmPlayer()
        {
            _session.Data.IsArmed = _playerInputReader._isArmed = true;
            UpdatePlayerWeapon();
        }

        private void UpdatePlayerWeapon()
        {
            _animator.runtimeAnimatorController = _session.Data.IsArmed ? _armed : _disarmed;
            _playerInputReader._isArmed = _session.Data.IsArmed;
        }

        private void FixedUpdate()
        {
            _isGrounded = IsGrounded();

            if(_isGrounded)
            {
                if (_lastVelocityY <= -14f || !_allowDoubleJump)
                {
                    if (_isSpawnFallParticle) 
                    {
                        FallParticleSpawner();
                        _isSpawnFallParticle = false;
                    }
                    _lastVelocityY = 0;
                }
            }
            else
            {
                _isSpawnFallParticle = true;
            }

            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _lastVelocityY = yVelocity;
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            UpdateAnimation();
        }
    }

}
