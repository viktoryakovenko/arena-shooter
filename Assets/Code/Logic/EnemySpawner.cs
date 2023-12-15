using Code.Infrastructure.Factory;
using Code.StaticData;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Logic
{
    public class EnemySpawner : ISpawner, ITickable
    {
        private const string NAME = "Enemies";

        private readonly ObjectPool _poolEnemies;
        private readonly SpawnerStaticData _spawnerData;
        private readonly EnemyFactory _enemyFactory;
        private readonly List<Transform> _spawnPoints;

        private List<GameObject> _enemies;
        private float _spawnTime;

        public EnemySpawner(EnemyFactory enemyFactory, SpawnerStaticData spawnerData)
        {
            _enemyFactory = enemyFactory;
            _spawnerData = spawnerData;
            _spawnPoints = _spawnerData.SpawnPoints;
            _enemies = new List<GameObject>();
            _spawnTime = 0;

            _poolEnemies = new ObjectPool(_enemyFactory, NAME, _spawnerData.MaxSize);
        }

        public void Tick()
        {
            if (_enemies.Count >= _spawnerData.MaxSize) return;

            _spawnTime += Time.deltaTime;
            if (_spawnTime > _spawnerData.SpawnInterval)
            {
                Spawn(GetRandomSpawnPoint());
                _spawnTime -= _spawnerData.SpawnInterval;
            }
        }

        public GameObject Spawn(Vector3 spawnPoint)
        {
            GameObject enemy = _poolEnemies.GetFreeElement();
            enemy.transform.position = spawnPoint;
            var health = enemy.GetComponent<IHealth>();
            health.Current = health.Max;

            _enemies.Add(enemy);

            return enemy;
        }

        private Vector3 GetRandomSpawnPoint()
        {
            int randomId = Random.Range(0, _spawnPoints.Count);
            return _spawnPoints[randomId].position;
        }
    }
}