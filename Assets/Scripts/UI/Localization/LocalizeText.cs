using System;
using Scripts.Model.Definitions.Localozation;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Localization
{
    [RequireComponent(typeof (Text))]
    public class LocalizeText : MonoBehaviour
    {
        [SerializeField] private string _key;

        private Text _text;
        
        private void Awake()
        {
            _text = GetComponent<Text>();

            LocalisationManager.I.OnLocaleChanged += OnLocaleChanged;
            Localize();
        }


        private void OnLocaleChanged()
        {
            Localize();    
        }

        private void Localize()
        {
            _text.text = LocalisationManager.I.Locolize(_key);
        }

        private void OnDestroy()
        {
            LocalisationManager.I.OnLocaleChanged -= OnLocaleChanged;
        }
    }
}