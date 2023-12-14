using Code.Hero;
using UnityEngine;

namespace Code.Enemy
{
    public class DamageOnCollision : MonoBehaviour
    {
        private float _damage;

        public void Construct(float damage)
        {
            _damage = damage;
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collision!");
            if (other.gameObject.TryGetComponent(out HeroHealth health))
            {
                health.TakeDamage(_damage);
                Deactivate();
            }
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}