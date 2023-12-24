using Code.Bullets;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
    public class BulletFactory : IFactory
    {
        private DiContainer _container;
        private Bullet _bulletPrefab;

        public BulletFactory(Bullet bullet, DiContainer container)
        {
            _bulletPrefab = bullet;
            _container = container;
        }

        public GameObject Create(Transform container = null) =>
            _container.InstantiatePrefab(_bulletPrefab.gameObject, container);
    }
}