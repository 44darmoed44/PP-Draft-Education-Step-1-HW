using UnityEngine;

namespace Scripts.Components
{
    public class CollectCoinsComponent : MonoBehaviour
    {
        private GameSession _numCoins;
        private int coinValue;

        private void Awake()
        {
            _numCoins = FindObjectOfType<GameSession>();
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

            _numCoins._totalCoinsValue += coinValue;
            Debug.Log(_numCoins._totalCoinsValue);
        }
    }
}
