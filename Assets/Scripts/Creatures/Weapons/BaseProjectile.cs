using UnityEngine;

namespace Scripts.Creatures.Weapons
{
    public class BaseProjectile : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        protected Rigidbody2D _rb;
        protected int _direction;
        protected Vector2 _position;

        protected virtual void Start()
        {
            _direction = transform.lossyScale.x > 0 ? 1 : -1;
            _rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            _position = _rb.position;
            _position.x += _direction * _speed;
        }
    }
}