using Code.Logic;
using UnityEngine;
using Zenject;

namespace Code.Hero.Skills
{
    public class KillAll : MonoBehaviour, ISkill
    {
        private EnemyCollection _enemyCollection;
        private IPower _power;

        [Inject]
        private void Construct(EnemyCollection enemyCollection)
        {
            _enemyCollection = enemyCollection;
        }

        private void Start()
        {
            _power = GetComponent<IPower>();
        }

        public void Use()
        {
            if (_power.Current == _power.Max)
            {
                _enemyCollection.Clear();
                _power.RemovePower(_power.Current);
            }
        }
    }
}