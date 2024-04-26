using Scripts.Model;
using UnityEngine;


namespace Scripts.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] protected GameSession _session;

        protected int SwordCount => _session.Data.Inventory.Count("Sword");
        protected int CoinsCount => _session.Data.Inventory.Count("Coin");

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _session.Data.Inventory.OnChanged += OnInventoryChanged;
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
    }
}