using Assets.Code.Logic;
using Code.Infrastructure.Factory;
using UnityEngine;

namespace Code.Logic
{
    public class BulletSpawner : ISpawner
    {
        private const string NAME = "Bullets";
        private const int MAX = 50;

        private readonly ObjectPool _poolBullets;
        private readonly BulletFactory _bulletFactory;

        public BulletSpawner(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;

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
