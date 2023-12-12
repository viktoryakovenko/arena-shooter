using Code.Infrastructure.Factory;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class BulletFactory : IFactory
    {
        private GameObject _bulletPrefab;

        public BulletFactory(GameObject prefab)
        {
            _bulletPrefab = prefab;
        }

        public GameObject Create(Transform container = null)
        {
            GameObject bullet = Object.Instantiate(_bulletPrefab, container);



            return bullet;
        }
    }
}