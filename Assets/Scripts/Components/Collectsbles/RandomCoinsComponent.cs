using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Components.Collectables
{
    public class RandomCoinsComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private int _numCoins;
        [SerializeField] private float _probabilityGoldCoin;
        [SerializeField] private float _probabilitySilverCoin;

        [SerializeField] private GameObject _goldCoinPrefab;
        [SerializeField] private GameObject _goldSilverPrefab;


        private GameObject[] RandomizeCoins()
        {
            var coinsList = new List<GameObject>();

            for (int i = 0; i < _numCoins; i++)
            {
                var chance = Random.Range(1, 100);

                if (chance-_probabilityGoldCoin <= 0)
                {
                    coinsList.Add(_goldCoinPrefab);
                }   
                else if (chance-_probabilitySilverCoin <= 0)
                {
                    coinsList.Add(_goldSilverPrefab);
                    break;
                }
            }
            return coinsList.ToArray();
        }

        public void SpawnCoins()
        {
            var coinsList = RandomizeCoins();

            Debug.Log(coinsList);

            if (coinsList.Length > 0)
            {
                foreach (var coin in coinsList)
                {
                    var position = new Vector3(_target.position.x+Random.Range(-0.5f, 0.5f), 
                                                _target.position.y+Random.Range(-0.1f, 0.5f), 
                                                _target.position.z); 

                    var inst = Instantiate(coin.gameObject, position, Quaternion.identity);
                    inst.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    inst.AddComponent<CapsuleCollider2D>();
                    inst.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.01f, 0.01f);
                    inst.GetComponent<CapsuleCollider2D>().size = new Vector2(0.1f, 0.3f);
                }
            }
        }
    }
}
