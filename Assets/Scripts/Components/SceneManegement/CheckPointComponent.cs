using Scripts.Components.GoBased;
using Scripts.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.SceneManegement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class CheckPointComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private SpawnComponent _playerSpawn;
        [SerializeField] private UnityEvent _setChecked;
        [SerializeField] private UnityEvent _setUnuhecked;

        public string Id => _id;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();

            if (_session.IsChecked(_id)) _setChecked?.Invoke();
            else _setUnuhecked?.Invoke();
        }

        public void Check()
        {
            _session.SetChecked(_id);
            _setChecked?.Invoke();
        }

        public void SpawnPlayer()
        {
            _playerSpawn.SetPrefabName("Player");
            _playerSpawn.Spawn();
        }
    }
}