using Code.Logic;
using System;
using UnityEngine;

namespace Code.Hero
{
    [AddComponentMenu("Hero/HeroPower")]
    public class HeroPower : MonoBehaviour, IPower
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
            if (amount <= 0) return;

            Current = Mathf.Min(Current + amount, _maxPower);
        }

        public void RemovePower(float amount)
        {
            if (amount <= 0) return;

            Current = Mathf.Max(Current - amount, 0);
        }
    }
}