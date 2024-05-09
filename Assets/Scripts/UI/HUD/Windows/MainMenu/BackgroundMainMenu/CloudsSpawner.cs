using System.Collections;
using Scripts.Creatures.Weapons;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Scripts.UI.HUD.Windows.MainMenu.BackgroundMainMenu
{
    public class CloudsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _container;

        [Space] [Header("Spawn delay")]
        [SerializeField] private float _minSpawnDelay;
        [SerializeField] private float _maxSpawnDelay;

        [Space] [Header("Clouds speed")]
        [SerializeField] private float _minCloudSpeed;
        [SerializeField] private float _maxCloudSpeed;

        private void Start()
        {
            StartCoroutine(SpawnCloudsTimer());
        }

        private IEnumerator SpawnCloudsTimer()
        {
            var delay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            SpawnClouds(_prefabs, _target);
            
            StartCoroutine(SpawnCloudsTimer());
        }

        private void SpawnClouds(GameObject[] prefabs, Transform target)
        {
            var id = Random.Range(0, prefabs.Length);
            var cloud = prefabs[id];

            var speedValue = Random.Range(_minCloudSpeed, _maxCloudSpeed);
            cloud.GetComponent<Projectile>().SetSpeed(-speedValue);

            var spawnPosY = Random.Range(_target.position.y+4, _target.position.y-1.60f);
            var position = new Vector3(transform.position.x, spawnPosY);

            Instantiate(cloud, position, Quaternion.identity, _container);
        }
    }
}