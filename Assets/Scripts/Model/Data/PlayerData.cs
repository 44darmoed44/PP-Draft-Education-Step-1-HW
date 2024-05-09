using System;
using System.Collections.Generic;
using Scripts.Model.Data.Properties;
using Scripts.Model.Definitions;
using UnityEngine;

namespace Scripts.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InventoryData _inventory;
        [SerializeField] private List<string> _perks = new List<string>();

        public InventoryData Inventory => _inventory;
        public List<string> Perks => _perks;

        public IntProperty Hp = new IntProperty();

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}