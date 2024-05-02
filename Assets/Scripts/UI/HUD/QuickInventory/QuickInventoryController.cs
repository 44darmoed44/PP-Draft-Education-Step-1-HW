using System.Collections.Generic;
using Scripts.Model;
using Scripts.Utils.Disposables;
using UnityEngine;

namespace Scripts.UI.HUD.QuickInventory
{
    public class QuickInventoryController : MonoBehaviour
    {
        [SerializeField] private Transform _container;   
        [SerializeField] private InventoryItemWidget _prefab;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private GameSession _session;
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.QuickInventory.Subscribe(Rebuild));
            Rebuild();
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }

        private void Rebuild()
        {
            var inventory = _session.QuickInventory.Inventory;

            // create required item
            for(var i = _createdItems.Count; i < inventory.Length; i++)
            {
                var item = Instantiate(_prefab, _container);
                _createdItems.Add(item);
            }

            // update data and activete
            for (var i = 0; i < inventory.Length; i++)
            {
                if (_createdItems[i] == null) continue;
                _createdItems[i].SetData(inventory[i], i);
                _createdItems[i].gameObject.SetActive(true);
            }

            // hide unused items
            for (int i = inventory.Length; i < _createdItems.Count; i++)
            {
                if (_createdItems[i] == null) continue;
                _createdItems[i].gameObject.SetActive(false);
            }
        }
    }
}