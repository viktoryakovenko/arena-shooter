using Code.Bullets;
using UnityEngine;
using Zenject;

namespace Code.Logic
{
    [RequireComponent(typeof(IAttack))]
    [RequireComponent(typeof(IHealth))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Bullet _bullet;

        private BulletSpawner _bulletSpawner;

        private void Awake()
        {
            _bulletSpawner = new BulletSpawner(_bullet);
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
