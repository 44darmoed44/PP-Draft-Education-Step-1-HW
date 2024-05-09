using UnityEngine;


namespace Scripts.UI.HUD.Windows.PerksWindow
{
    public class SpawnPerksWindow : MonoBehaviour
    {
        private PerkManager _windowPerk;

        public void Spawn()
        {
            _windowPerk = FindObjectOfType<PerkManager>();

            if (_windowPerk == null)
            {
                var window = Resources.Load<GameObject>("UI/PerksWindow");
                var canvas = FindObjectOfType<Canvas>();
                Instantiate(window, canvas.transform);
            }
            
            return;
        }
    }
}