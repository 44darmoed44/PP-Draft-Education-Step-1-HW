using Scripts.Model;
using Scripts.Model.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components.Interactions
{
    public class RequireItemComponent : MonoBehaviour
    {
        [SerializeField] private InventoryItemData[] _requied;
        [SerializeField] private bool _removeAfterUse;

        [SerializeField] private UnityEvent _onSuccess;
        [SerializeField] private UnityEvent _onFail;

        public void Check()
        {
            var session = FindObjectOfType<GameSession>();
            var areAllRequierementsMet = true;
            foreach (var item in _requied)
            {
                var numItems = session.Data.Inventory.Count(item.Id);
                if (numItems < item.Value) areAllRequierementsMet = false;
            }
            if (areAllRequierementsMet)
            {
                if (_removeAfterUse)
                {
                    foreach (var item in _requied) session.Data.Inventory.Remove(item.Id, item.Value);
                }

                _onSuccess?.Invoke();
            }
            else
            {
                _onFail?.Invoke();
            }
        }
    }
}