using System;
using UnityEngine;

namespace Code.Hero
{
    [AddComponentMenu("Hero/Death")]
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        public event Action Happened;

        public HeroHealth Health;

        private bool _isDead;

        private void Start() =>
            Health.StateChanged += HealthChanged;

        private void OnDestroy() =>
            Health.StateChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!_isDead && Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Health.StateChanged -= HealthChanged;
            Happened?.Invoke();

            Destroy(gameObject);
        }
    }
}