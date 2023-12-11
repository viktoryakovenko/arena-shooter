using Code.Infrastructure.Factory;
using Code.StaticData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Code.Logic
{
    public class EnemySpawner : ISpawner, ITickable
    {
        private ObjectPool<GameObject> _poolEnemies;
        private SpawnerStaticData _spawnerData;
        private EnemyFactory _enemyFactory;
        private List<Transform> _spawnPoints;
        private float _spawnTime;
        private List<GameObject> _enemies;

        public EnemySpawner(EnemyFactory enemyFactory, SpawnerStaticData spawnerData)
        {
            _enemyFactory = enemyFactory;
            _spawnerData = spawnerData;
            _spawnPoints = _spawnerData.SpawnPoints;
            _enemies = new List<GameObject>();

            _poolEnemies = new ObjectPool<GameObject>(createFunc: CreateEnemy, 
                actionOnGet: GetEnemy, 
                actionOnRelease: ReleaseEnemy, 
                actionOnDestroy: DestroyEnemy, 
                maxSize: _spawnerData.MaxSize);
        }

        public void Tick()
        {
            if (_enemies.Count >= _spawnerData.MaxSize) return;

            _spawnTime += Time.deltaTime;
            if (_spawnTime > _spawnerData.SpawnInterval)
            {
                Spawn();
                _spawnTime -= _spawnerData.SpawnInterval;
            }
        }

        public void Spawn()
        {
            _enemies.Add(_poolEnemies.Get());
        }

        private GameObject CreateEnemy()
        {
            var randomSpawnPoint = Random.Range(0, _spawnPoints.Count);

            return _enemyFactory.Create(_spawnPoints[randomSpawnPoint].position);
        }

        private void GetEnemy(GameObject enemy)
        {
            enemy.SetActive(true);
        }

        private void ReleaseEnemy(GameObject enemy)
        {
            enemy.SetActive(false);
        }

        private void DestroyEnemy(GameObject enemy)
        {
            Object.Destroy(enemy.gameObject);
        }
    }
}