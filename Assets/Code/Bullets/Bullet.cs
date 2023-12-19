using UnityEngine;
using System.Collections;
using Code.Logic;

namespace Code.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;

        protected IHealth _owner;
        protected float _damage;

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

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);

            Deactivate();
        }

        protected void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
