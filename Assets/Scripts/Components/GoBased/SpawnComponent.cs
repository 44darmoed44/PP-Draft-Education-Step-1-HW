using System;
using Scripts.Model.Definitions;
using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject[] _prefabs;

        private string _particleName;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            foreach (var item in _prefabs)
            {
                if (_particleName.Contains(item.gameObject.name))
                {
                    var instantiate = Instantiate(item.gameObject, _target.position, Quaternion.identity);
                    instantiate.transform.localScale = transform.lossyScale;
                    return;
                }
            }
        }

        public void SetPrefab(GameObject prefab)
        {
            _particleName = prefab.gameObject.name;
        }

        public void SetPrefabName(string name)
        {
            _particleName = name;
        }
    }
}
