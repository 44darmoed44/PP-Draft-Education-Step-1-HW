using System.Collections;
using Scripts.Components.ColliderBase;
using Scripts.Components.GoBased;
using Scripts.Creatures.Patroling;
using UnityEngine;

namespace Scripts.Creatures
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;
        [SerializeField] private LayerCheck _canAttack;
        [SerializeField] private SpawnComponent _alarmParticle;

        [SerializeField] private float _alarmDelay;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _timeToDie;
        [SerializeField] private float _timeToBackPatrol;

        private Coroutine _current;
        private GameObject _target;    

        private Creature _creature;
        private Animator _animator;

        private static readonly int IsDeadKey = Animator.StringToHash("is-dead");

        private bool _isDead;

        private Patrol _patrol;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }


        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }


        public void OnPlayerInVision(GameObject go)
        {
            if (_isDead) return;

            _target = go;

            StartState(AgroToPlayer());
        }

        private IEnumerator AgroToPlayer()
        {
            LookAtPlayer();
            _alarmParticle.Spawn("Alarm");
            yield return new WaitForSeconds(_alarmDelay);
            StartState(GoToPlayer());
        }

        private void LookAtPlayer()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(Vector2.zero);
            _creature.UpdateSpriteDirection(direction);
        }


        private IEnumerator GoToPlayer()
        {
            while (_vision.IsTouchingLayer)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }
                SetDirectionToTarget();
                yield return null;
            }

            _creature.SetDirection(Vector2.zero);
            yield return new WaitForSeconds(_timeToBackPatrol);
            StartState(_patrol.DoPatrol());
        }        

        private IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(GoToPlayer());
        }

        private void SetDirectionToTarget()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(direction);
        }

        private Vector2 GetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;

            return direction.normalized;
        }

        private void StartState(IEnumerator coroutine)
        {  
            if (_current != null)
                StopCoroutine(_current);

            _current = StartCoroutine(coroutine);
        }

        public void OnDie()
        {
            _isDead = true;
            _animator.SetBool(IsDeadKey, true);
            _creature.SetDirection(Vector2.zero);
            StartState(Die());
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(_timeToDie);

            Destroy(gameObject); 
        }
    }
}