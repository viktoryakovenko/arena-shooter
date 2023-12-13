using Code.Infrastructure.AssetManagment;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class BulletFactory : IFactory
    {
        private GameObject _bulletPrefab;

        public BulletFactory() => 
            _bulletPrefab = Resources.Load<GameObject>(AssetPath.BulletPath);

        public GameObject Create(Transform container = null) => 
            Object.Instantiate(_bulletPrefab, container);
    }
}