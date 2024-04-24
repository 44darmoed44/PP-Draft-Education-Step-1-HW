using UnityEngine;


namespace Scripts.Components
{  
    public class ArmPlayerComponent : MonoBehaviour
    {

        public void ArmPlayer(GameObject go)
        {
            var player = go.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ArmPlayer();
            }
        }
    }
}