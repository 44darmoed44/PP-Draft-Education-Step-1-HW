using UnityEngine;
using UnityEngine.InputSystem;


namespace Scripts
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private PlayerController _playerController;
        private PlayerInputAction _inputActions;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();

            _inputActions = new PlayerInputAction();

            _inputActions.Player.Movement.performed += OnMovement;
            _inputActions.Player.Movement.canceled += OnMovement;

            _inputActions.Player.OnSaySomething.canceled += OnSaySomething;

            _inputActions.Player.OnInteract.canceled += OnInteract;
        }

        private void OnDestroy()
        {
            _inputActions.Player.Movement.performed -= OnMovement;
            _inputActions.Player.Movement.canceled -= OnMovement;

            _inputActions.Player.OnSaySomething.canceled -= OnSaySomething;

            _inputActions.Player.OnInteract.canceled -= OnInteract;
        }

        private void OnEnable()
        {
            _inputActions.Enable();
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

