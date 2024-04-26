using System.Collections;
using UnityEngine;

namespace Scripts.Creatures.Patroling
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}