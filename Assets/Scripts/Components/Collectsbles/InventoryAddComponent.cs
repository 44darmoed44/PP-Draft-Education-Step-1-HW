using Scripts.Model.Definitions;
using Scripts.Player;
using UnityEngine;

namespace Scripts.Components.Collectables
{
    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _id;   
        [SerializeField] private int _value; 

        public void Add(GameObject go)
        {
            var player = go.GetComponent<PlayerBase>();
            if (player != null) player.AddInInventory(_id, _value); 
        }  
    }
}