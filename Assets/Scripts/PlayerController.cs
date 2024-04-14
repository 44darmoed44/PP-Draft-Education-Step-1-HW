using System;
using Scripts.Components;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] private float _inputTimeToLive;        
        [SerializeField] private CheatItem[] _cheats;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _interactionLayer;
        
        private Collider2D[] _interactionResult = new Collider2D[1];
        private string _currentInput;
        private float _inputTime;

        private void Awake()
        {
            Keyboard.current.onTextInput += OnTextInput;
        }

        private void OnDestroy()
        {
            Keyboard.current.onTextInput -= OnTextInput;
        }

        private void OnTextInput(char inputChar)
        {
            _currentInput += inputChar;
            _inputTime = _inputTimeToLive;
            FindAnyCheats();
        }

        private void FindAnyCheats()
        {
            foreach (var cheatItem in _cheats)
            {
                if (_currentInput.Contains(cheatItem.Name))
                {
                    cheatItem.Action?.Invoke();
                    _currentInput = string.Empty;
                }
            }
        }

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _interactionRadius,
                                                        _interactionResult, _interactionLayer);

            for (int i = 0; i < size; i++)
            {
                var interactable = _interactionResult[i].GetComponent<InteractableComponent>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        private void Update()
        {
            if (_inputTime < 0)
            {
                _currentInput = string.Empty;
            }
            else
            {
                _inputTime -= Time.deltaTime;
            }
        }
    }
}

[Serializable]
public class CheatItem
{
    public string Name;
    public UnityEvent Action;
}