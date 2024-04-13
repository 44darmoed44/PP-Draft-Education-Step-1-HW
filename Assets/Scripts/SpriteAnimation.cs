using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;

        private bool _isPlaying = true;

        private SpriteRenderer _spriteRenderer;
        private float _fps;
        private int _currentSpriteIndex;
        private float _nextFrameTime;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _fps = 1f/_frameRate;
            _nextFrameTime = Time.time + _fps;
        }

        private void Update()
        {
            if(!_isPlaying || _nextFrameTime > Time.time) return;

            if(_currentSpriteIndex >= _sprites.Length)
            {
                if (_loop)
                {
                    _currentSpriteIndex = 0;
                }
                else
                {
                    _isPlaying = false;
                    _onComplete.Invoke();
                    return;
                }
            }
            
            _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
            _nextFrameTime += _fps;
            _currentSpriteIndex++;
        }
    }
}