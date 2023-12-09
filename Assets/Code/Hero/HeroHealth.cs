using Code.Logic;
using System;
using UnityEngine;

namespace Code.Hero
{
    public class HeroHealth : MonoBehaviour, IHealth
    {
        public event Action StateChanged;

        [SerializeField] private float _currentHp;
        [SerializeField] private float _maxHp;

        public float Current
        {
            get => _currentHp;
            set
            {
                if (_currentHp != value)
                {
                    _currentHp = value;

                    StateChanged?.Invoke();
                }
            }
        }

        public float Max 
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        public void TakeDamage(float amount)
        {
            if (Current <= 0) return;

            Current -= amount;
        }
    }
}