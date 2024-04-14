using Scripts.Components;
using UnityEngine;

namespace Scripts
{
    public class PlayerHeall : MonoBehaviour
    {
        private int _health;
        
        public void Heall()
        {   
            _health = GetComponent<HealthComponent>()._health;
            Debug.Log(_health);
        }
    }
}