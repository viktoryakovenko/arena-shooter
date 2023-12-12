using System;
using UnityEngine;
using Code.Logic;

namespace Assets.Code.Logic
{
    public class Bullet : MonoBehaviour
    {
        public event Action OnHit;

        public IHealth Owner => _owner;
        public float LifetimeSeconds => _lifetimeSeconds;

        [SerializeField, Range(1f, 3f)] private float _lifetimeSeconds = 2f;
        IHealth _owner;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                if (health.GetType() != _owner.GetType())
                {
                    health.TakeDamage(50);
                }
            }
        }
    }
}
