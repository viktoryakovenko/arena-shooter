using System;
using UnityEngine;
using Code.Logic;
using System.Collections;

namespace Assets.Code.Logic
{
    public class Bullet : MonoBehaviour
    {
        public event Action OnHit;

        [SerializeField] private float _lifeTime = 2f;

        private IHealth _owner;
        private float _damage;

        public void Construct(IHealth owner, float damage)
        {
            _owner = owner;
            _damage = damage;
        }

        private void OnEnable()
        {
            StartCoroutine(LifeRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(LifeRoutine());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IHealth health))
            {
                if (health.GetType() != _owner.GetType())
                {
                    health.TakeDamage(_damage);
                    Deactivate();
                }
            }
            else
            {
                Deactivate();
            }
        }

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);

            Deactivate();
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
