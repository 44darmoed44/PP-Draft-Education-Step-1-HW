using UnityEngine;


namespace Scripts.Components
{
  public class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;

        public void Teleport(GameObject target)
        {
            target.transform.position = _targetPosition.transform.position;
        }
    }  
}
