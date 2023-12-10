using Code.Enemy;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Factory
{
    public class EnemyFactory
    {
        private readonly List<Type> _enemies = new List<Type>()
        {
            typeof(RedEnemy),
            typeof(BlueEnemy),
        };

        public IEnemy Create()
        {
            var enemyIndex = Random.Range(0, _enemies.Count);
            var typeOfEnemy = _enemies[enemyIndex];

            IEnemy enemy = Activator.CreateInstance(typeOfEnemy) as IEnemy;

            return enemy;
        }
    }
}
