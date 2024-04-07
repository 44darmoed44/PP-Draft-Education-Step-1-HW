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

        _inputActions.Player.HorizontalMovement.performed += OnHorizontalMovement;
        _inputActions.Player.HorizontalMovement.canceled += OnHorizontalMovement;

        _inputActions.Player.VerticalMovement.performed += OnVerticalMovement;
        _inputActions.Player.VerticalMovement.canceled += OnVerticalMovement;

        _inputActions.Player.OnSaySomething.performed += OnSaySomething;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<float>();
        _playerMovement.SetDirection(direction, 0);
    }

    private void OnVerticalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<float>();
        _playerMovement.SetDirection(0, direction);
    }

    private void OnSaySomething(InputAction.CallbackContext context)
    {
        _playerMovement.SaySomething();
    }

}
