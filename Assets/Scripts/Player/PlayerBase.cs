using JetBrains.Annotations;
using Scripts.Audio;
using Scripts.Model;
using UnityEngine;


namespace Scripts.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] protected GameSession _session;

        protected int SwordCount => _session.Data.Inventory.Count("Sword");
        protected int CoinsCount => _session.Data.Inventory.Count("Coin");

        private PlaySoundsComponent _playSounds;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _session.Data.Inventory.OnChanged += OnInventoryChanged;
            _playSounds = GetComponent<PlaySoundsComponent>();
        }

        private void OnDestroy()
        {
            _session.Data.Inventory.OnChanged -= OnInventoryChanged; 
        }

        protected virtual void OnInventoryChanged(string id, int value)
        {
        }

        public void AddInInventory(string id, int value)
        {
            _session.Data.Inventory.Add(id, value);
        }

        public void PlaySound(string id)
        {
            _playSounds.Play(id);
        }
    }
}