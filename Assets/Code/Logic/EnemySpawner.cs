using Code.Infrastructure.Factory;
using Code.StaticData;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Code.Logic
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
                Spawn();
                _spawnTime -= _spawnerData.SpawnInterval;
            }
        }

        public void Spawn()
        {
            GameObject enemy = _poolEnemies.GetFreeElement();

            var randomSpawnPoint = Random.Range(0, _spawnPoints.Count);
            enemy.transform.position = _spawnPoints[randomSpawnPoint].position;

            _enemies.Add(enemy);
        }
    }
}