using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Logic
{
    public class EnemyCollection
    {
        private List<GameObject> _enemies;

        public int Count => _enemies.Count;

        public EnemyCollection()
        {
            _enemies = new List<GameObject>();
        }

        public EnemyCollection(List<GameObject> enemies)
        {
            _enemies = enemies;
        }

        public void AddEnemy(GameObject enemy)
        {
            if (enemy == null)
                throw new NullReferenceException();

            _enemies.Add(enemy);
        }

        public void RemoveEnemy(GameObject enemy)
        {
            _enemies.Remove(enemy);
        }

        public void Clear()
        {
            foreach (GameObject enemy in _enemies)
                enemy.gameObject.SetActive(false);

            _enemies.Clear();
        }
    }
}