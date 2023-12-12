using Code.Logic;
using System;
using UnityEngine;

namespace Code.Enemy
{
    [AddComponentMenu("Enemy/Health")]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public event Action StateChanged;

        [SerializeField] private float _current;
        [SerializeField] private float _max;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float amount)
        {
            Current -= amount;

            StateChanged?.Invoke();
        }
    }
}