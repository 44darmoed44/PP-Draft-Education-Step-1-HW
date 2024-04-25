using System;
using Scripts.Components;
using UnityEngine;

namespace Scripts.Creatures
{
    [Serializable]
    public class ModuleTrap : MonoBehaviour
    {
        [SerializeField] private SpawnComponent _rangeAttack;

        public int Id;
        public Animator Animator;

        public void DoRangeAttack()
        {
            _rangeAttack.Spawn("WoodSpike");
        }
    }
}