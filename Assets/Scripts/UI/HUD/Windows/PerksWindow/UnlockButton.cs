using Scripts.Model;
using UnityEngine;

namespace Scripts.UI.HUD.Windows.PerksWindow
{
    public class UnlockButton : MonoBehaviour
    {
        [SerializeField] InfoWidget _info;

        private GameSession _session;
        private PerkManager _perkManager;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _perkManager = FindObjectOfType<PerkManager>();
        }

        public void OnUnlocked()
        {
            var price = _info.PriceValue;

            _session.Data.Perks.Add(_info.Id);
            _session.Data.Inventory.Remove("Diamond", price);

            _perkManager.UpdatePerksTree();

            _info.UpdateInfo();
        }
    }
}