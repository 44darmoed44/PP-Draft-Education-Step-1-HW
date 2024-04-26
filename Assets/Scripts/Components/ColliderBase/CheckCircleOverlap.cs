using System.Collections.Generic;
using Scripts.Components;
using Scripts.Components.Health;
using Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Scripts.Components.ColliderBase
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;

        private readonly Collider2D[] _interactionResult = new Collider2D[10];

        public GameObject[] GetObjectsInRange()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _interactionResult);

            var overlaps = new List<GameObject>();
            for (int i = 0; i < size; i++)
            {
                overlaps.Add(_interactionResult[i].gameObject);
            }

            return overlaps.ToArray();
        }


        public void Check(string tag, int value)
        {
            var gos = GetObjectsInRange();
            foreach (var go in gos)
            {
                var hp = go.GetComponent<HealthComponent>();
                if (hp != null && go.CompareTag(tag))
                {
                    hp.ModifyHealth(-value);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = HandlesUtils.TransparentRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }
    }
}
    