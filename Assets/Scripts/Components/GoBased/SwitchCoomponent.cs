using UnityEngine;

namespace Scripts.Components.GoBased
{
    public class SwitchCoomponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string _animtionKey;

        public void Awake()
        {
            _animator.SetBool(_animtionKey, _state);
        }

        public void Switch()
        {
            _state = !_state;
            _animator.SetBool(_animtionKey, _state);
        }

        [ContextMenu ("Switch")]
        public void SwitchIt()
        {
            Switch();
        }
    }  
}
    