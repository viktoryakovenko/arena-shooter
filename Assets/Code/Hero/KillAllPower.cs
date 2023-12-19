using Code.Logic;
using System;
using UnityEngine;

namespace Code.Hero
{
    [AddComponentMenu("Hero/KillAll Power")]
    public class KillAllPower : MonoBehaviour, IPower
    {
        public event Action StateChanged;

        [SerializeField] private float _currentPower;
        [SerializeField] private float _maxPower;

        public float Current
        {
            get => _currentPower;
            set
            {
                if (_currentPower != value)
                {
                    _currentPower = value;

                    StateChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _maxPower;
            set => _maxPower = value;
        }

        public void AddPower(float amount)
        {
            if (Current <= 0) return;

            Current += amount;
        }

        public void RemovePower(float amount)
        {
            if (Current <= 0) return;

            Current -= amount;
        }
    }
}