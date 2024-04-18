using UnityEngine;

namespace Scripts.Components
{
    public class CollectCoinsComponent : MonoBehaviour
    {
        private PlayerCoins _playerCoins;
        private int coinValue;

        private void Awake()
        {
            _playerCoins = FindObjectOfType<PlayerCoins>();
        }

        public void OnCollectCoin()
        {
            if (gameObject.CompareTag("SilverCoin"))
            {
                coinValue = 1;
            }
            else if (gameObject.CompareTag("GoldenCoin"))
            {
                coinValue = 10;
            }

            var totalCoins = _playerCoins.GetTotalCoinsValue();
            _playerCoins.SetTotalCoinsValue(totalCoins+coinValue);
        }
    }
}
