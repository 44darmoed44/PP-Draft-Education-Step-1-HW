using Scripts.Components;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Scripts
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private Animator _playerAnimator;
        private PlayerController _playerController;
        public PlayerInputAction inputActions;

        private static readonly int attackKey = Animator.StringToHash("Attack");

        public bool _isArmed;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();

            inputActions = new PlayerInputAction();

            inputActions.Player.Movement.performed += OnMovement;
            inputActions.Player.Movement.canceled += OnMovement;

            inputActions.Player.OnAttack.canceled += OnAttack;

            inputActions.Player.OnInteract.canceled += OnInteract;
        }

        private void OnDestroy()
        {
            inputActions.Player.Movement.performed -= OnMovement;
            inputActions.Player.Movement.canceled -= OnMovement;

            inputActions.Player.OnAttack.canceled -= OnAttack;

            inputActions.Player.OnInteract.canceled -= OnInteract;
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

        private void OnAttack(InputAction.CallbackContext context)
        {
            if (!_isArmed) return;
            _playerAnimator.SetTrigger(attackKey);
        }

        public void Attack()
        {
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

    }
}

