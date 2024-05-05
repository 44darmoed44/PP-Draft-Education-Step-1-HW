using System.Collections.Generic;
using Scripts.Model.Definitions.Localozation;
using UnityEngine;


namespace Scripts.UI.HUD.Windows.LanguageMenu
{
    public class LanguageWindow : AnimatedWindow
    {
        [SerializeField] private Transform _containter;
        [SerializeField] private LocaleItemWidget _prefab;

        private DataGroup<LocaleInfo, LocaleItemWidget> _dataGroup;
        
        private string[] _supportedLocales = new[] {"en", "ru", "pl"};

        protected override void Start()
        {
            base.Start();
            _dataGroup = new DataGroup<LocaleInfo, LocaleItemWidget>(_prefab, _containter);
            _dataGroup.SetData(ComposeData());
        }       

        private List<LocaleInfo> ComposeData()
        {
            var data = new List<LocaleInfo>();
            foreach (var locale in _supportedLocales)
            {
                data.Add(new LocaleInfo {LocaleId = locale});
            }

            return data;
        }

        public void OnSelected(string selectedLocale)
        {
            LocalisationManager.I.SetLocale(selectedLocale);
        }
    }
}