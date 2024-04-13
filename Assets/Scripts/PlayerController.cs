using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpScale;

        [SerializeField] private LayerCheck _groundCheck;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

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


        private void UpdateAnimation(bool isGrounded)
        {
            _animator.SetFloat(vetricalVelocityKey, _rigidbody.velocity.y);
            _animator.SetBool(isGroundKey, isGrounded);
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


        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);

            var isJumping = _direction.y > 0;
            var isGrounded = IsGrounded();
            if (isJumping)
            {
                if (isGrounded )
                {
                    _rigidbody.AddForce(Vector2.up * _jumpScale, ForceMode2D.Impulse);
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }

            UpdateAnimation(isGrounded);
        }
    }

}
