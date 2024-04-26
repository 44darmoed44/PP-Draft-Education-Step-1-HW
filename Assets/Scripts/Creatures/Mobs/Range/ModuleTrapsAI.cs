using UnityEngine;

namespace Scripts.Creatures.Mobs.Range
{
    public class ModuleTrapsAI : ShootingTrapAI
    {
        [SerializeField] private ModuleTrap[] _traps;
        private int _idFire;

        protected override void Awake()
        {
            base.Awake();
        }
        
        protected override void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_rangeCooldown.IsReady)
                {
                    RangeAttack();
                }
            } 
        }

        protected void RangeAttack()
        {
            foreach (var item in _traps)
            {
                if (item == null) continue;
                if (_idFire == item.Id)
                {
                    item.Animator.SetTrigger(Range);
                    break;
                }
            }

            _idFire += 1;
            if (_idFire >= _traps.Length) _idFire = 0;

            _rangeCooldown.Reset();
        }
    }
}