using System;
using System.Collections.Generic;
using Scripts.Model.Data.Properties;
using UnityEngine;

namespace Scripts.Model.Definitions.Localozation
{
    public class LocalisationManager
    {
        public readonly static LocalisationManager I;

        private StringPersistentProperty _localeKey = new StringPersistentProperty("en", "localization/current");
        private Dictionary<string, string> _localeDict;

        public Action OnLocaleChanged;

        static LocalisationManager()
        {
            I = new LocalisationManager();
        }   

        public LocalisationManager()
        {
            LoadLocale(_localeKey.Value);
        }

        public string LocaleKey => _localeKey.Value;

        private void LoadLocale(string localeToLoad)
        {
            var def = Resources.Load<LocaleDef>($"Localizations/{localeToLoad}");
            _localeDict = def.GetData();
            _localeKey.Value = localeToLoad;
            OnLocaleChanged?.Invoke();
        }

        public string Locolize(string key)
        {
            if (_localeDict.TryGetValue(key, out var value))
            {
                return value;
            }
            return $"%%%{key}%%%";
        }

        internal void SetLocale(string localeKey)
        {
            LoadLocale(localeKey);
        }
    }
}