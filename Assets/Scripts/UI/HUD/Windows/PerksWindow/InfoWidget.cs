using Assets.Scripts.UI.Localization;
using Scripts.Model;
using Scripts.Model.Data;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.UI.HUD.Windows.PerksWindow
{
    public class InfoWidget : MonoBehaviour
    {
        [SerializeField] private LocalizeText _infoText;

        [SerializeField] private Text _priceValueText;
        [SerializeField] private Text _totalValueText;

        [SerializeField] private Button _unlockButton;


        private string _currentSelectId;

        public string CurrentSelectId => _currentSelectId;

        private int _priceValue;
        private int _totalValue;
        private string _infoKey = "default_perk_info";
        private string _id;
        private bool _isLocked;

        public string Id => _id;
        public int PriceValue => _priceValue;
        public int TotalValue => _totalValue;

        private InventoryItemData _diamond;

        private void Start()
        {
            var session = FindObjectOfType<GameSession>(); 
            _diamond = session.Data.Inventory.GetItem("Diamond");

            UpdateInfo();
        }

        public void UpdateInfo()
        {
            _infoText.Key = _infoKey;

            _priceValueText.text = PriceValue == 0 ? "---" : PriceValue.ToString();

            _totalValue = _diamond == null ? 0 : _diamond.Value;
            _totalValueText.text = TotalValue.ToString();

            if (TotalValue >= PriceValue && _isLocked) 
                _unlockButton.interactable = true;
            else
                _unlockButton.interactable = false;
        }

        public void SetInfoProperty(string id, string infoKey, int priceValue, bool isLocked)
        {
            _id = id;
            _infoKey = infoKey;
            _priceValue = priceValue;
            _isLocked = isLocked;

            UpdateInfo();
        }
    }
}