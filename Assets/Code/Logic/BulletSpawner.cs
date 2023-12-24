using Code.Bullets;
using Code.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Code.Logic
{
    public class BulletSpawner : ISpawner
    {
        private const string NAME = "Bullets";
        private const int MAX = 20;

        private readonly ObjectPool _poolBullets;
        private readonly BulletFactory _bulletFactory;

        public BulletSpawner(Bullet bullet, DiContainer container)
        {
            _bulletFactory = new BulletFactory(bullet, container);

            _poolBullets = new ObjectPool(_bulletFactory, NAME, MAX);
            _poolBullets.AutoExpand = true;
        }

        public GameObject Spawn(Vector3 spawnPoint)
        {
            GameObject bullet = _poolBullets.GetFreeElement();
            bullet.transform.position = spawnPoint;

            return bullet;
        }
    }
}
