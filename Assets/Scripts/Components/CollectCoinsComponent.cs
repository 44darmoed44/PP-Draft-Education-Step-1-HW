using System.Runtime.InteropServices;
using UnityEngine;

namespace Scripts.Components
{
    public class CollectCoinsComponent : MonoBehaviour
    {
        [SerializeField] private Inventory _numCoins;
        private int coinValue;

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
