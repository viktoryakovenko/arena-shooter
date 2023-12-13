using Assets.Code.Logic;
using Code.Infrastructure.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic
{
    public class BulletSpawner : ISpawner
    {
        private const string NAME = "Bullets";
        private const int MAX = 200;

        private readonly Transform _spawnPoint;
        private readonly ObjectPool _poolBullets;
        private readonly BulletFactory _bulletFactory;

        private List<GameObject> _bullets;

        public BulletSpawner(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _bullets = new List<GameObject>();

            _poolBullets = new ObjectPool(_bulletFactory, NAME, MAX);
            _poolBullets.AutoExpand = true;
        }

        public void Spawn()
        {
            GameObject bullet = _poolBullets.GetFreeElement();

            bullet.transform.position = _spawnPoint.position;

            _bullets.Add(bullet);
        }
    }
}
