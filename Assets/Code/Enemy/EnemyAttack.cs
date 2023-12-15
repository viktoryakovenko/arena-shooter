using Code.Logic;
using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Attack")]
    public class EnemyAttack : MonoBehaviour, IAttack
    {
        public float Damage { get; set; }

        [SerializeField] private float _attackCooldown;

        private float _currentCooldown = 0;
        private Gun _gun;

        private void Awake()
        {
            _gun = GetComponent<Gun>();
        }

        private void Update()
        {
            Attack();
        }

        public void Attack()
        {
            _currentCooldown -= Time.deltaTime;

            if (_currentCooldown < 0)
            {
                _gun.Shoot();
                _currentCooldown += _attackCooldown;
            }
        }
    }
}