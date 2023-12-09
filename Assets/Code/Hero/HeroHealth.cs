using Code.Logic;
using Code.StaticData;
using System;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    public class HeroHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;

        private float _currentHp;
        private float _maxHp;

        public float Current
        {
            get => _currentHp;
            set
            {
                if (_currentHp != value)
                {
                    _currentHp = value;

                    HealthChanged?.Invoke();
                }
            }
        }

        public float Max 
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        [Inject]
        private void Construct(HeroStaticData staticData)
        {
            _maxHp = staticData.MaxHealth;
            _currentHp = staticData.MaxHealth;
            HealthChanged?.Invoke();
        }

        public void TakeDamage(float amount)
        {
            if (Current <= 0) return;

            Current -= amount;
        }
    }
}