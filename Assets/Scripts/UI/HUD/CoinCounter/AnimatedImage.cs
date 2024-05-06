using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.UI.HUD.CoinCounter
{
    [RequireComponent(typeof(Image))]
    public class AnimatedImage : MonoBehaviour
    {
        [SerializeField] private int _frameRate = 10;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clips;

        private Image _image;

        private float _fps;
        private int _currentSpriteIndex;
        private float _nextFrameTime;
        private bool _isPlaying = true;

        private int _currentClip;

        private void Start()
        {
            _image = GetComponent<Image>();
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

        public virtual void SetClip(string clipName)
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


        protected void StartAnimation()
        {
            _nextFrameTime = Time.time + _fps;
            enabled = _isPlaying = true;
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
                    enabled = _isPlaying = clip.AllowNextClip;
                    clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);
                    if (clip.AllowNextClip)
                    {
                        _currentSpriteIndex = 0;
                        _currentClip = (int) Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }

                return;
            }

            
            _image.sprite = clip.Sprites[_currentSpriteIndex];
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