using Code.Logic;
using UnityEngine;

namespace Code.Bullets
{
    public class PowerBullet : Bullet
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IPower power))
            {
                power.RemovePower(Damage);
                Deactivate();
            }
            else
            {
                Deactivate();
            }
        }
    }
}