using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Enemy
{
    public class EnemyMoveToPlayer : Follow
    {
        [SerializeField] private NavMeshAgent _agent;

        private Transform _heroTransform;

        [Inject]
        public void Construct(Transform heroTransform) =>
            _heroTransform = heroTransform;

        private void Update() =>
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            if (_heroTransform)
                _agent.destination = _heroTransform.position;
        }
    }
}