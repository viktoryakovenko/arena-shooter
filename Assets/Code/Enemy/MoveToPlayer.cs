using Code.Hero;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
    public class MoveToPlayer : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        private Transform _heroTransform;

        [Inject]
        public void Construct(HeroMovement heroMovement) =>
            _heroTransform = heroMovement.gameObject.transform;

        private void Update() =>
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            //Vector3.MoveTowards(transform.position, _heroTransform.position, MoveSpeed * Time.deltaTime);
        }
    }
}