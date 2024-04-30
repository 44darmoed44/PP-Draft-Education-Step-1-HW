using System.Collections;
using Scripts.Model;
using Scripts.Model.Definitions;
using Scripts.UI.Widgets;
using UnityEngine;


namespace Scripts.UI.HUD
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ProgressBarWidget _healthBar;

        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _session.Data.Hp.OnChanged += OnHealChanges;
        }

        private void OnHealChanges(int newValue, int oldValue)
        {
            var maxHealth = DefsFacade.I.Player.MAXHealth;
            var value = (float) newValue / maxHealth;
            _healthBar.SetProgress(value);
        }

        private void OnDestroy()
        {
            _session.Data.Hp.OnChanged -= OnHealChanges;
        }
    }
}