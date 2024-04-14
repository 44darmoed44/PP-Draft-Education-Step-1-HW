using UnityEngine;

namespace Scripts.Components
{
    public class ChangeHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _changeHealthValue;

        public void ApplyDamage(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null) healthComponent.ApplyDamage(_changeHealthValue);
        }

        public void ApplyHeall(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null) healthComponent.ApplyHeall(_changeHealthValue);
        }
    }
}