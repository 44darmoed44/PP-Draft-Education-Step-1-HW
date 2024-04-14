using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clips;

        private SpriteRenderer _spriteRenderer;

        private float _fps;
        private int _currentSpriteIndex;
        private float _nextFrameTime;
        private bool _isPlaying = true;

        private int _currentClip;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _fps = 1f/_frameRate;

            StartAnimation();
        }

        private void OnBecameVisible()
        {
            enabled = _isPlaying;
        }

        private void OnBecameInvisible()
        {
            enabled = false;
        }

        public void SetClip(string clipName)
        {
            for (var i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == clipName)
                {
                    _currentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }


        private void StartAnimation()
        {
            _nextFrameTime = Time.time + _fps;
            _isPlaying = true;
            _currentSpriteIndex = 0;
        }

        private void OnEnable()
        {
            _nextFrameTime = Time.time + _fps;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            var clip = _clips[_currentClip];
            if (_currentSpriteIndex >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    _currentSpriteIndex = 0;
                }
                else
                {
                    clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);
                    enabled = _isPlaying = clip.AllowNextClip;
                    if (clip.AllowNextClip)
                    {
                        _currentSpriteIndex = 0;
                        _currentClip = (int) Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }

                return;
            }

            
            _spriteRenderer.sprite = clip.Sprites[_currentSpriteIndex];
            _nextFrameTime += _fps;
            _currentSpriteIndex++;
        }


        [Serializable]
        public class AnimationClip
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite[] _sprites;
            [SerializeField] private bool _loop;
            [SerializeField] private bool _allowNextClip;
            [SerializeField] private UnityEvent _onComplete;

            public string Name => _name;
            public Sprite[] Sprites => _sprites;
            public bool Loop => _loop;
            public bool AllowNextClip => _allowNextClip;
            public UnityEvent OnComplete => _onComplete;
        }
    }
}