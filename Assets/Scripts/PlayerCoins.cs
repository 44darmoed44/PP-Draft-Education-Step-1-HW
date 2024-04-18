using UnityEngine;

namespace Scripts
{
    public class PlayerCoins : MonoBehaviour
    {
        [SerializeField] private int _totalCoinsValue;

        public void SetTotalCoinsValue(int value)
        {
            _totalCoinsValue = value;
            Debug.Log(_totalCoinsValue);
        }

        public int GetTotalCoinsValue()
        {
            return _totalCoinsValue;
        }
    } 
}
