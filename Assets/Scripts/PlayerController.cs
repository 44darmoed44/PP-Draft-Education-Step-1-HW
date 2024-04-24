using System;
using System.Net;
using Scripts.Components;
using Scripts.Utils;
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
        [SerializeField] private CollectionSwordComponent _totalSwords;
        
        [SerializeField] private SpawnComponent _particles;

        [SerializeField] private Cooldown _throwCooldown;

        private Collider2D[] _interactionResult = new Collider2D[1];
        private string _currentInput;
        private float _inputTime;

        private static readonly int ThrowKey = Animator.StringToHash("Throw");
        private Animator _animator;

        private void Awake()
        {
            Keyboard.current.onTextInput += OnTextInput;
            _animator = GetComponent<Animator>();
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

        public void Throw()
        {
            if (_throwCooldown.IsReady && _totalSwords._totalNumSword > 1)
            {
                _animator.SetTrigger(ThrowKey);
                _throwCooldown.Reset();
                _totalSwords._totalNumSword -= 1;
            }
        }

        public void OnDoThrow()
        {
            _particles.Spawn("SwordThrow");
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