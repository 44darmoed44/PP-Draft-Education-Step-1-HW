using Scripts.Components;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.Creatures
{
    public class ShootingTrapAI : MonoBehaviour
    {
        [SerializeField] protected LayerCheck _vision;

        [Header("Melee")]
        [SerializeField] private CheckCircleOverlap _meleeAttack;
        [SerializeField] private LayerCheck _meleeCanAttack;
        [SerializeField] private Cooldown _meleeCooldown;
        
        [Header("Range")]
        [SerializeField] protected Cooldown _rangeCooldown;
        [SerializeField] protected SpawnComponent _rangeAttack;       
        
        protected Animator _animator;
        private static readonly int Melee = Animator.StringToHash("melee");
        protected static readonly int Range = Animator.StringToHash("range");
    

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_meleeCanAttack.IsTouchingLayer)
                {
                    if (_meleeCooldown.IsReady)
                    {
                        MeleeAttack();
                    }
                    return;
                }

                if (_rangeCooldown.IsReady)
                {
                    RangeAttack();
                }
            }
        }

        private void MeleeAttack()
        {
            _meleeCooldown.Reset();
            _animator.SetTrigger(Melee);
        }

        private void RangeAttack()
        {
            _rangeCooldown.Reset();
            _animator.SetTrigger(Range);
        }

        public void OnMeleeAttack()
        {
            _meleeAttack.Check("Player", 1);
        }

        public void OnRangeAttack()
        {
            _rangeAttack.Spawn("PerlThrowSin");
        }
    }
}