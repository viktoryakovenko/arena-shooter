using Code.Logic;
using UnityEngine;

namespace Code.Bullets
{
    public class HealthBullet : Bullet
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IHealth health))
            {
                if (health.GetType() != _owner.GetType())
                {
                    health.TakeDamage(_damage);
                    Deactivate();
                }
            }
            else
            {
                Deactivate();
            }
        }
    }
}