using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private PlayerInputAction _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInputAction();

        _inputActions.Player.Movement.performed += OnMovement;
        _inputActions.Player.Movement.canceled += OnMovement;

        _inputActions.Player.OnSaySomething.performed += OnSaySomething;
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

}
