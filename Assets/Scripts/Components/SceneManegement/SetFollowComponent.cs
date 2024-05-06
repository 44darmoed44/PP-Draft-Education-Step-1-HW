using Cinemachine;
using Scripts.Player;
using UnityEngine;

namespace Scripts.Components.SceneManegement
{
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            var vCamera = FindObjectOfType<CinemachineVirtualCamera>();
            vCamera.Follow = FindObjectOfType<PlayerBase>().transform;
        }   
    }
}