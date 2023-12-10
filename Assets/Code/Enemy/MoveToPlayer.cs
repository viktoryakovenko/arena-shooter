using Code.Hero;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
    public class MoveToPlayer : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;

        private Transform _heroTransform;

        [Inject]
        public void Construct(HeroMovement heroMovement) =>
            _heroTransform = heroMovement.transform;

        private void Update() =>
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            Vector3.MoveTowards(transform.position, _heroTransform.position, _moveSpeed * Time.deltaTime);
        }
    }
}