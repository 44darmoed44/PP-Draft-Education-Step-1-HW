using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Scripts.UI.HUD.Windows.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        private Action _closeAction;

        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/SettingsWindow");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }   

        public void OnStartGames()
        {
            _closeAction = () => { SceneManager.LoadScene("Level 1"); };
            Close();
        }

        public void OnExit()
        {
            _closeAction = () => {
                Application.Quit();


#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            };

            Close();
        }

        public override void OnCloseAnimationComplete()
        {
            base.OnCloseAnimationComplete();
            _closeAction?.Invoke();
        }
    }
}