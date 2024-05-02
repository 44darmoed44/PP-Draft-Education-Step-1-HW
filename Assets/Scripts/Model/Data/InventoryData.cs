using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Model.Definitions;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] private int _maxNumberOfItems;
        [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

        public delegate void OnInventoryChanged(string id, int value);

        public OnInventoryChanged OnChanged;

        public void Add(string id, int value)
        {
            if (CountNumItems() == _maxNumberOfItems && _maxNumberOfItems != 0)
            {
                Debug.Log("Oops, it seems you don't have enough space in your inventory.");
                return;
            }

            if (value <= 0) return;

            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null || id.Contains("Unstakable"))
            {
                item = new InventoryItemData(id);
                _inventory.Add(item);
            }

            item.Value += value;

            OnChanged?.Invoke(id, value);
        }

        public InventoryItemData[] GetAll(params ItemTag[] tags)
        {
            var retValue = new List<InventoryItemData>();
            foreach (var item in _inventory)
            {
                var itemDef = DefsFacade.I.Items.Get(item.Id);
                var isAllRequiremetsMet = tags.All(x => itemDef.HashTag(x));
                if (isAllRequiremetsMet) retValue.Add(item);
            }
            return retValue.ToArray();
        }

        public void Remove(string id, int value)
        {
            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null) return;

            item.Value -= value;

            if (item.Value <= 0) _inventory.Remove(item);
            
            OnChanged?.Invoke(id, value);
        }

        public int Count(string id)
        {
            var count = 0;
            foreach (var item in _inventory)
            {
                if (item.Id == id) count = item.Value;
            }
            return count;
        }

        private int CountNumItems()
        {
            var count = 0;
            foreach (var item in _inventory)
            {
                if (item.Id != "Coin")
                {
                    count += item.Value;
                }
            }
            return count;
        }

        public InventoryItemData GetItem(string id)
        {
            foreach (var itemData in _inventory)
            {
                if (itemData.Id == id) return itemData;
            }

            return null;
        }
    }

    [Serializable]
    public class InventoryItemData
    {
        public string Id;
        public int Value;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}