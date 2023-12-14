using UnityEngine;
using Zenject;

namespace Code.Logic
{
    [RequireComponent(typeof(IAttack))]
    [RequireComponent(typeof(IHealth))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;

        private BulletSpawner _bulletSpawner;

        [Inject]
        private void Construct(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }

        public void Shoot()
        {
            Bullet bullet = _bulletSpawner.Spawn(_bulletSpawnPoint.position).GetComponent<Bullet>();
            bullet.Construct(GetComponent<IHealth>(), GetComponent<IAttack>().Damage);
            bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
            bullet.transform.forward = _bulletSpawnPoint.forward;
        }
    }
}
