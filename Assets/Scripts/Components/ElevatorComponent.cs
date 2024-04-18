using UnityEngine;

namespace Scripts.Components
{
    public class ElevatorComponent : MonoBehaviour
    {
        [SerializeField] private Transform _startTarget;
        [SerializeField] private Transform _changeDirectionTarget;
        [SerializeField] private Transform _finishTarget;
        [SerializeField] private float _speed;
        [SerializeField] private float _direction;
        [SerializeField] private bool _workFlag;
        [SerializeField] private bool _changeDirection;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        [ContextMenu("change flag")]
        public void ChangeWorkFlag()
        {
            _workFlag = !_workFlag;
        }

        private void FixedUpdate()
        {
            if (_workFlag)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _direction*_speed*Time.deltaTime);

                if (_changeDirection)
                {
                    if ((_rb.position.y >= _startTarget.position.y) || (_rb.position.y <= _finishTarget.position.y))
                    {
                        _direction = -_direction;
                        _changeDirection = false;
                        _workFlag = !_workFlag;
                    }
                }
            }
            else
            {
                _rb.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == _changeDirectionTarget.gameObject.name)
            {
                _changeDirection = true;
            }
        }
    } 
}
