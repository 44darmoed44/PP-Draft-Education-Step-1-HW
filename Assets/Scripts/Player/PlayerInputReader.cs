using JetBrains.Annotations;
using Scripts.Components.ColliderBase;
using Scripts.Components.Health;
using Scripts.Model.Definitions;
using Scripts.Player;
using Scripts.UI.MainMenu;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;


namespace Scripts
{
    public class PlayerInputReader : PlayerBase
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private Animator _playerAnimator;
        private PlayerController _playerController;
        private HealthComponent _healthComponent;
        public PlayerInputAction inputActions;

        private static readonly int attackKey = Animator.StringToHash("Attack");

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _playerController = GetComponent<PlayerController>();

            inputActions = new PlayerInputAction();

            inputActions.Player.Movement.performed += OnMovement;
            inputActions.Player.Movement.canceled += OnMovement;

            inputActions.Player.OnAttack.canceled += OnAttack;

            inputActions.Player.OnInteract.canceled += OnInteract;

            inputActions.Player.Throw.performed += OnThrow;

            inputActions.Player.OnUseItem.performed += OnUseItems;

            inputActions.Player.OnPause.performed += OnPause;

            inputActions.Player.NextItem.performed += OnNextItem;
        }

        private void OnDestroy()
        {
            inputActions.Player.Movement.performed -= OnMovement;
            inputActions.Player.Movement.canceled -= OnMovement;

            inputActions.Player.OnAttack.canceled -= OnAttack;

            inputActions.Player.OnInteract.canceled -= OnInteract;

            inputActions.Player.Throw.performed -= OnThrow;

            inputActions.Player.OnUseItem.performed -= OnUseItems;

            inputActions.Player.OnPause.performed -= OnPause;

            inputActions.Player.NextItem.performed -= OnNextItem;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _playerMovement.SetDirection(direction);
        }

        private void OnUseItems(InputAction.CallbackContext context)
        {

            var potionId = _session.QuickInventory.SelectedItem.Id;
            var healthChangeValue = 0;

            if (potionId.Contains("Potion"))
            {
                if (potionId.Contains("Small"))
                {
                    healthChangeValue = 2;
                }
                else if (potionId.Contains("Big"))
                {
                    healthChangeValue = 5;
                }

                _session.Data.Hp.Value += healthChangeValue;
                if (_session.Data.Hp.Value > DefsFacade.I.Player.MAXHealth) 
                    _session.Data.Hp.Value = DefsFacade.I.Player.MAXHealth;
                _session.Data.Inventory.Remove(potionId, 1);

                _healthComponent._health = _session.Data.Hp.Value;

                PlaySound("PotionUse");
            }
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            if (!(SwordCount > 0)) return;
            _playerAnimator.SetTrigger(attackKey);
        }
        
        public void Attack()
        {
            if (SwordCount <= 0) return;

            var gos = _attackRange.GetObjectsInRange();
            foreach (var go in gos)
            {
                var hp = go.GetComponent<HealthComponent>();
                if (hp != null && go.CompareTag("Enemy"))
                {
                    hp.ModifyHealth(-_damage);
                }
            }
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            _playerController.Interact();
        }

        private void OnThrow(InputAction.CallbackContext context)
        {
            _playerController.Throw();
        }

        private void OnNextItem(InputAction.CallbackContext context)
        {
            _session.QuickInventory.SetNextItem();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            var pauseWindow = FindObjectOfType<MainMenuWindow>();
            if (pauseWindow != null)
            {
                pauseWindow.Close();
            }
            else
            {
                var window = Resources.Load<GameObject>("UI/PauseMenuWindow");
                var canvas = FindObjectOfType<Canvas>();
                Instantiate(window, canvas.transform);
            }
        }

    }
}

