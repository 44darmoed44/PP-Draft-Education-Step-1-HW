using UnityEngine;


namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryItemsDef _items;
        [SerializeField] private PlayerDef _player;

        public InventoryItemsDef Items => _items;  
        public PlayerDef Player => _player;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDef() : _instance;

        private static DefsFacade LoadDef()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}