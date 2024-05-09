using UnityEngine;


namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryItemsDef _items;
        [SerializeField] private ThrowableItemsDef _throwableItems;
        [SerializeField] private PerksDef _perks;
        [SerializeField] private PlayerDef _player;

        public InventoryItemsDef Items => _items;  
        public ThrowableItemsDef Throwable => _throwableItems;  
        public PlayerDef Player => _player;
        public PerksDef Perks => _perks;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDef() : _instance;

        private static DefsFacade LoadDef()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}