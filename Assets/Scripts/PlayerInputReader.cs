using UnityEngine;
using UnityEngine.InputSystem;


namespace Scripts
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private PlayerController _playerController;
        public PlayerInputAction inputActions;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();

            inputActions = new PlayerInputAction();

            inputActions.Player.Movement.performed += OnMovement;
            inputActions.Player.Movement.canceled += OnMovement;

            inputActions.Player.OnSaySomething.canceled += OnSaySomething;

            inputActions.Player.OnInteract.canceled += OnInteract;
        }

        private void OnDestroy()
        {
            inputActions.Player.Movement.performed -= OnMovement;
            inputActions.Player.Movement.canceled -= OnMovement;

            inputActions.Player.OnSaySomething.canceled -= OnSaySomething;

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

        private void OnSaySomething(InputAction.CallbackContext context)
        {
            _playerMovement.SaySomething();
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            _playerController.Interact();
        }

    }
}

