using System;
using UnityEngine;
namespace Scripts.Model.Definitions
{

    [CreateAssetMenu(menuName = "Defs/PerksDef", fileName = "PerksDef")]
    public class PerksDef : ScriptableObject
    {
        [SerializeField] private PerksData[] _perks;

        public PerksData[] PerksList { get => _perks; }

        public PerksData GetPerkDataFromPerksList(string id)
        {
            foreach (var perk in _perks)
            {
                if (perk.PerkItem.Id == id) return perk;
            }

            return null;
        }
    }


    [Serializable]
    public class PerksData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _infoKey;
        [SerializeField] private PerkItem _perkItem;

        public Sprite Icon => _icon;
        public string InfoKey => _infoKey;
        public PerkItem PerkItem => _perkItem;
    }

    [Serializable]
    public class PerkItem
    {
        [SerializeField] private string _id;
        [SerializeField] private string _section;
        [SerializeField] private int _row;
        [SerializeField] private int _price;

        public string Id => _id;
        public int Price => _price;
        public string Section { get => _section; }
        public int Row { get => _row; }
    }
}