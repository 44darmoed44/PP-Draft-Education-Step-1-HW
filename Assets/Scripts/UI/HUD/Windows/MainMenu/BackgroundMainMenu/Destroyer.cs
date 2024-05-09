using UnityEngine;

namespace Scripts.UI.HUD.Windows.MainMenu.BackgroundMainMenu
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }   
    }
}