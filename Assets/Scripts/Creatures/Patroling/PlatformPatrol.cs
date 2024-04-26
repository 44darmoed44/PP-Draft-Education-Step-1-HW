using System.Collections;
using UnityEngine;

namespace Scripts.Creatures.Patroling
{
    public class PlatformPatrol : Patrol
    {
        public override IEnumerator DoPatrol()
        {
            yield return null;
        }
    }
}