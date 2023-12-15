using Code.Hero;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Move To Player")]
    public class MoveToPlayer : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        private Transform _heroTransform;

        [Inject]
        private void Construct(HeroMovement heroMovement) =>
            _heroTransform = heroMovement.transform;

        private void Update() =>
            SetDestinationForAgent();

        private void SetDestinationForAgent()
        {
            if (_heroTransform != null) 
                transform.position = Vector3.MoveTowards(transform.position, _heroTransform.position, MoveSpeed * Time.deltaTime);
        }
    }
}