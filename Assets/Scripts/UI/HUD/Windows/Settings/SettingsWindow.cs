using Scripts.Model.Data.Properties;
using Scripts.UI.Widgets;
using UnityEngine;


namespace Scripts.UI.HUD.Windows.Settings
{
    public class SettingsWindow : AnimatedWindow
    {
        [SerializeField] private AudioSettingsWidget _music;
        [SerializeField] private AudioSettingsWidget _sfx;
        protected override void Start()
        {
            base.Start();

            _music.SetModel(GameSettings.I.Music);
            _sfx.SetModel(GameSettings.I.Sfx);
        }

        public void OnShowLanguage()
        {
            var window = Resources.Load<GameObject>("UI/LanguageSettingMenu");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }
    }
}