using UnityEngine;

namespace Scripts.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject[] _prefabs;

        [ContextMenu("Spawn")]
        public void Spawn(string particleName)
        {
            foreach (var item in _prefabs)
            {
                if (particleName.Contains(item.gameObject.name))
                {
                    var instantiate = Instantiate(item.gameObject, _target.position, Quaternion.identity);
                    instantiate.transform.localScale = transform.lossyScale;
                    return;
                }
            }
        }
    }
}
