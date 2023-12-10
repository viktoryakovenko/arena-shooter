using Code.Enemy;
using Code.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Assets.Code.Logic
{
    public class EnemySpawner : ISpawner
    {
        private EnemyFactory _enemyFactory;

        [Inject]
        private void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Spawn(Vector3 position, Transform parent = null)
        {
            IEnemy enemy = _enemyFactory.Create();

            if (enemy != null)
                Object.Instantiate(enemy as MonoBehaviour, position, Quaternion.identity, parent);
        }
    }
}
