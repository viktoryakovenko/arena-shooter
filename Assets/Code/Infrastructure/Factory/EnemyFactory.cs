using Code.Enemy;
using Code.Logic;
using Code.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Factory
{
    public class EnemyFactory
    {
        private readonly List<EnemyTypeId> _enemiesId = new List<EnemyTypeId>();
        private EnemyStaticDataService _staticData;

        public EnemyFactory(EnemyStaticDataService staticData) 
        {
            _staticData = staticData;
            _staticData.LoadEnemies();

            var enemyTypes = Enum.GetValues(typeof(EnemyTypeId));

            foreach (int id in enemyTypes)
                _enemiesId.Add((EnemyTypeId)id);
        }

        public GameObject Create(Vector3 spawnPosition)
        {
            EnemyStaticData enemyData = GetRandomEnemyData();
            GameObject enemy = Object.Instantiate(enemyData.Prefab, spawnPosition, Quaternion.identity, null);

            IHealth health = enemy.GetComponent<IHealth>();
            health.Current = enemyData.Hp;
            health.Max = enemyData.Hp;

            enemy.GetComponent<MoveToPlayer>().MoveSpeed = enemyData.MoveSpeed;

            enemy.GetComponent<EnemyAttack>().Damage = enemyData.Damage;

            return enemy;
        }

        private EnemyStaticData GetRandomEnemyData()
        {
            EnemyStaticData enemyStaticData = ScriptableObject.CreateInstance<EnemyStaticData>();
            List<EnemyStaticData> enemiesData = new List<EnemyStaticData>();
            int weightSum = 0;


            foreach (var id in _enemiesId)
                enemiesData.Add(_staticData.ForEnemy(id));

            foreach (var enemyData in enemiesData)
                weightSum += enemyData.SpawnWeight;

            var randomWeight = Random.Range(0, weightSum);

            foreach (var enemyData in enemiesData)
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
    }
}
