using UnityEngine;

namespace Scripts.Components.Health
{
    public class ChangeHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _changeHealthValue;

        public void Apply(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null) healthComponent.ModifyHealth(_changeHealthValue);
        }
    }
}