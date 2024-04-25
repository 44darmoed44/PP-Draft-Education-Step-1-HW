using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace Scripts.Creatures.Weapons
{
    public class SinusoidaProjectile : BaseProjectile
    {
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private float _amplitude = 1f;
        private float _originalY;
        private float _time;

        protected override void Start()
        {
            base.Start();
            _originalY = _rb.position.y;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            _position.y = _originalY + Mathf.Sin(_time * _frequency) * _amplitude;
            _rb.MovePosition(_position);
            _time += Time.fixedDeltaTime;
        }
    }
}