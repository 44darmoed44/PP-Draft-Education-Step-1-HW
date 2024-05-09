using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.HUD.Windows.PerksWindow
{
    public class PerkWidget : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _isLocked;
        [SerializeField] private GameObject _isSelected;

        private string _id;

        public GameObject IsSelected => _isSelected;
        public string Id => _id;

        private PerkManager _perkManager;


        private void Start()
        {
            _perkManager = FindObjectOfType<PerkManager>();
            _isSelected.SetActive(false);
        }

        public void UpdateWidget(string id, Sprite icon, bool isLocked)
        {
            _id = id;
            _icon.sprite = icon;
            _isLocked.SetActive(isLocked);
        }

        public void OnSelect()
        {
            _perkManager.UpdatePerkSelected(_id);
        }
    }
}