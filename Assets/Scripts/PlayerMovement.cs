using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpScale;

        [SerializeField] private LayerCheck _groundCheck;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        [SerializeField]private bool _isGrounded;
        [SerializeField]private bool _allowDoubleJump;

        private static readonly int isGroundKey = Animator.StringToHash("isGrounded");
        private static readonly int isRunningKey = Animator.StringToHash("isRunning");
        private static readonly int vetricalVelocityKey = Animator.StringToHash("vetricalVelocity");


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
                _spriteRenderer.flipX = false;
            }
            else if (_direction.x  < 0)
            {
                _spriteRenderer.flipX = true;
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
                _allowDoubleJump = false;
            }

            return yVeocity;
        }


        private void Update()
        {
            _isGrounded = IsGrounded();
        }


        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            UpdateAnimation();
        }
    }

}
