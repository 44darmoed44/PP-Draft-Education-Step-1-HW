using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Scripts.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FadeAnimation : MonoBehaviour
    {
        [SerializeField] private float _fadeDelay;
        [SerializeField] private float _fadeSpeed;
        [SerializeField] private UnityEvent _oAnimationFinish;

        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            StartCoroutine(OnFadeAnimation());
        }

        private IEnumerator OnFadeAnimation()
        {
            var currentAlpha = _sprite.color.a;
            if (currentAlpha <= 0)
            {
                StopCoroutine(OnFadeAnimation());
                _oAnimationFinish?.Invoke();
            }

            _sprite.color = new Color(255, 255, 255, currentAlpha - _fadeSpeed);
            yield return new WaitForSeconds(_fadeDelay);

            StartCoroutine(OnFadeAnimation());
        }
    }
}