using Scripts.Components;
using Scripts.Model;
using UnityEngine;

namespace Scripts
{
    public class PlayerDataLoad : MonoBehaviour
    {
        private HealthComponent _healthComponent;
        private PlayerCoins _playerCoins;
        private PlayerInputReader _playerInputReader;

        private GameSession _gameSession;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _playerCoins = GetComponent<PlayerCoins>();
            _playerInputReader = GetComponent<PlayerInputReader>();

            _gameSession = FindObjectOfType<GameSession>();
        }

        private void Start()
        {
            _healthComponent._health = _gameSession.Data.Hp;
            _playerCoins._totalCoinsValue = _gameSession.Data.Coins;
            _playerInputReader._isArmed = _gameSession.Data.IsArmed;
        }
    }
}