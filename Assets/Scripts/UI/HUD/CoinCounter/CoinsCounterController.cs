using System;
using System.Collections;
using System.Runtime.Serialization;
using Scripts.Model;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.UI.HUD.CoinCounter
{
    public class CoinsCounterController : MonoBehaviour
    {
        [SerializeField] private Text _totalCoinsText;
        [SerializeField] private Text _newCoinsText;
        [SerializeField] private GameObject _conteiner;

        [SerializeField] private float _hideDelay;
        [SerializeField] private float _addCoinsDelay;

        private Animator _animator;
        private GameSession _session;

        private int _totalCoinsValue;

        private int _bufferValue;
        private int _newCoinsValue;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _session = FindObjectOfType<GameSession>();

            _session.Data.Inventory.OnChanged += OnChangedCoinsValue;

            _totalCoinsValue = _session.Data.Inventory.GetItem("Coin").Value;
        }

        private void OnChangedCoinsValue(string id, int value)
        {
            if (!id.Equals("Coin")) return;
            StopAllCoroutines();
            OnShow(); 
        }

        public void OnShow()
        {
            var currentCoins = _session.Data.Inventory.GetItem("Coin").Value;
            if (currentCoins < _totalCoinsValue) return;

            CountSubtraction(currentCoins);
            _conteiner.SetActive(true);
            _animator.SetBool("IsShown", true);
        }

        private void CountSubtraction(int currentCoins)
        {
            _newCoinsValue = (_totalCoinsValue - currentCoins) * -1;
            _bufferValue = currentCoins;
            StartCoroutine(AddCoinsAnimation());
        }

        public IEnumerator AddCoinsAnimation()
        {
            if (_newCoinsValue == 0) 
            {
                _totalCoinsValue = _bufferValue;
                StopAllCoroutines();
                StartCoroutine(HideAnimation());
            }

            yield return new WaitForSeconds(_addCoinsDelay);

            _newCoinsValue--; 
            var substract = _bufferValue - _newCoinsValue;
            _totalCoinsText.text = substract.ToString();
            _newCoinsText.text = _newCoinsValue.ToString();
            
            StartCoroutine(AddCoinsAnimation());
        }

        private IEnumerator HideAnimation()
        {
            yield return new WaitForSeconds(_hideDelay);

            OnHide();
        }

        public void OnHide()
        {
            _animator.SetBool("IsShown", false);
        }

        public void OnHideAnimationComplete()
        {
            _conteiner.SetActive(false);
        }

        private void OnDestroy()
        {
            _session.Data.Inventory.OnChanged -= OnChangedCoinsValue;
        }
    }
}