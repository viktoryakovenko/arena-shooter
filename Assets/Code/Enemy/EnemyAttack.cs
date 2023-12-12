using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Attack")]
    public class EnemyAttack : MonoBehaviour
    {
        public float Damage { get; set; }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {

        }
    }
}