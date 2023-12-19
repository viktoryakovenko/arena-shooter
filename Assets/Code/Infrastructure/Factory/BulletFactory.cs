using Code.Bullets;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class BulletFactory : IFactory
    {
        private Bullet _bulletPrefab;

        public BulletFactory(Bullet bullet) => 
            _bulletPrefab = bullet;

        public GameObject Create(Transform container = null) => 
            Object.Instantiate(_bulletPrefab.gameObject, container);
    }
}