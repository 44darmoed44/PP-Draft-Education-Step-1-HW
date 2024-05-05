using System;
using Scripts.Model.Definitions.Localozation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.UI.HUD.Windows.LanguageMenu
{
    public class LocaleItemWidget : MonoBehaviour, IItemRenderer<LocaleInfo>
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _selector;
        [SerializeField] SelectLocale _onSelected;

        private LocaleInfo _data;

        private void Start()
        {
            LocalisationManager.I.OnLocaleChanged += OnLocaleChanged;
        }

        private void OnLocaleChanged()
        {
            bool isSelected = LocalisationManager.I.LocaleKey == _data.LocaleId;
            _selector.SetActive(isSelected);
        }

        public void SetData(LocaleInfo localeInfo, int index)
        {
            _data = localeInfo;
            OnLocaleChanged();
            _text.text = localeInfo.LocaleId.ToUpper();
        }

        public void OnSelected()
        {
            _onSelected?.Invoke(_data.LocaleId);
        }

        private void OnDestroy()
        {
            LocalisationManager.I.OnLocaleChanged -= OnLocaleChanged;
        }
    }

    [Serializable]
    public class SelectLocale : UnityEvent<string>
    {

    }

    public class LocaleInfo
    {
        public string LocaleId;
    }
}