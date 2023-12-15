using System;
using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Death")]
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        public event Action Happened;

        public EnemyHealth Health;

        private void OnEnable() => 
            Health.StateChanged += HealthChanged;

        private void OnDisable() => 
            Health.StateChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Health.StateChanged -= HealthChanged;
            Happened?.Invoke();

            gameObject.SetActive(false);
        }
    }
}