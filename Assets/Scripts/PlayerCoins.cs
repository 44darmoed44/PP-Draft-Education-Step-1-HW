using Scripts.Model;
using UnityEngine;

namespace Scripts
{
    public class PlayerCoins : MonoBehaviour
    {
        public int _totalCoinsValue;
        private GameSession _session;

        private void Awake()
        {
            _session = FindObjectOfType<GameSession>();
        }

        public void SetTotalCoinsValue(int value)
        {
            _totalCoinsValue = value;
            _session.Data.Coins = _totalCoinsValue;
            Debug.Log(_totalCoinsValue);
        }

        public int GetTotalCoinsValue()
        {
            return _totalCoinsValue;
        }
    } 
}
