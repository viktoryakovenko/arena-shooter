using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.StaticData
{
    public class EnemyStaticDataService
    {
        Dictionary<EnemyTypeId, EnemyStaticData> _enemies;

        public void LoadEnemies() => 
            _enemies = Resources
                .LoadAll<EnemyStaticData>("StaticData/Enemies")
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId) => 
            _enemies.TryGetValue(enemyTypeId, out EnemyStaticData staticData)
                ? staticData
                : null;
    }
}