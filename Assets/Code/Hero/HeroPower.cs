using Code.StaticData;
using System;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    public class HeroPower : MonoBehaviour
    {
        public event Action PowerChanged;

        private float _currentPower;
        private float _maxPower;

        public float Current
        {
            get => _currentPower;
            set
            {
                if (_currentPower != value)
                {
                    _currentPower = value;

                    PowerChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _maxPower;
            set => _maxPower = value;
        }

        [Inject]
        private void Construct(HeroStaticData staticData)
        {
            _currentPower = staticData.CurrentPower;
            _maxPower = staticData.MaxPower;
            PowerChanged?.Invoke();
        }

        public void TakeDamage(float amount)
        {
            if (Current <= 0) return;

            Current -= amount;
        }
    }
}