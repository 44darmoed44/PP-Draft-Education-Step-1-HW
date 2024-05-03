
using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Scripts.Model.Data;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.UI.HUD.Dialog
{
    public class DialogBoxController : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _container;
        [SerializeField] private Animator _animtor;

        [Space]
        [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")]
        [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _close;
        [SerializeField] private AudioClip _open;

        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        private DialogData _data;
        private int _currentSentence;
        private AudioSource _sfxSounds;
        private Coroutine _typingRoutin;


        private void Start()
        {
            _sfxSounds = AudioUtils.FindSfxSource();
        }

        public void ShowDialog(DialogData data)
        {
            _data = data;
            _currentSentence = 0;
            _text.text = string.Empty;

            _sfxSounds.PlayOneShot(_open);
            _container.SetActive(true);
            _animtor.SetBool(IsOpen, true);
        }

        private IEnumerator TypeDialogText()
        {
            _text.text = string.Empty;
            var sentence = _data.Sentences[_currentSentence];
            
            foreach (var letter in sentence)
            {
                _text.text += letter;
                _sfxSounds.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }

            _typingRoutin = null;
        }

        public void OnSkip()
        {
            if (_typingRoutin == null) return;

            StopTypeAnimation();
            _text.text = _data.Sentences[_currentSentence];
        }

        private void StopTypeAnimation()
        {
            if (_typingRoutin != null) StopCoroutine(_typingRoutin);
            _typingRoutin = null;
        }

        public void OnContinue()
        {
            if (_typingRoutin != null)
            {
                OnSkip();
                return;
            }
            _currentSentence++;

            var isDialogCompleted = _currentSentence >= _data.Sentences.Length;
            if (isDialogCompleted)
            {
                HideDialogBox();
            }
            else
            {
                OnStartDialogAnimation();
            }
        }

        private void HideDialogBox()
        {
            _animtor.SetBool(IsOpen, false);
            _sfxSounds.PlayOneShot(_close);
        }

        public void OnStartDialogAnimation()
        {
            _typingRoutin = StartCoroutine(TypeDialogText());
        }


        public void OnCloseAnimationComplete()
        {

        }
    }  
}