using Code.Enemy;
using Code.Logic;
using Code.StaticData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Factory
{
    public class EnemyFactory : IFactory
    {
        private readonly EnemyStaticDataService _staticData;
        private readonly DiContainer _diContainer;

        private List<EnemyStaticData> _enemiesData = new List<EnemyStaticData>();
        private int _enemiesWeight;

        public EnemyFactory(EnemyStaticDataService staticData, DiContainer diContainer)
        {
            _staticData = staticData;
            _staticData.LoadEnemies();

            _diContainer = diContainer;

            var enemyTypes = Enum.GetValues(typeof(EnemyTypeId));

            List<EnemyTypeId> enemiesId = new List<EnemyTypeId>();

            foreach (int id in enemyTypes)
                enemiesId.Add((EnemyTypeId)id);

            FindEnemiesWeight(enemiesId);
        }

        public GameObject Create(Transform container = null)
        {
            EnemyStaticData enemyData = GetRandomEnemyData();
            GameObject enemy = _diContainer.InstantiatePrefab(enemyData.Prefab, container);

            IHealth health = enemy.GetComponent<IHealth>();
            health.Current = enemyData.Hp;
            health.Max = enemyData.Hp;

            enemy.GetComponent<MoveToPlayer>().MoveSpeed = enemyData.MoveSpeed;

            enemy.GetComponent<DamageOnCollision>()?.Construct(enemyData.Damage);

            return enemy;
        }

        private EnemyStaticData GetRandomEnemyData()
        {
            EnemyStaticData enemyStaticData = ScriptableObject.CreateInstance<EnemyStaticData>();

            var randomWeight = Random.Range(0, _enemiesWeight);

            foreach (var enemyData in _enemiesData)
            {
                if (randomWeight < enemyData.SpawnWeight)
                {
                    enemyStaticData = enemyData;
                    break;
                }
                randomWeight -= enemyData.SpawnWeight;
            }

            return enemyStaticData;
        }

        private void FindEnemiesWeight(List<EnemyTypeId> enemiesId)
        {
            _enemiesWeight = 0;

            foreach (var id in enemiesId)
                _enemiesData.Add(_staticData.ForEnemy(id));

            foreach (var enemyData in _enemiesData)
                _enemiesWeight += enemyData.SpawnWeight;
        }
    }
}
