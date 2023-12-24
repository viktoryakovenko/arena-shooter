using UnityEngine;
using Code.Logic;

namespace Code.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Bullet : MonoBehaviour
    {
        public IHealth Owner => _owner;
        public float Damage => _damage;

        private IHealth _owner;
        private float _damage;

        public void Construct(IHealth owner, float damage)
        {
            _owner = owner;
            _damage = damage;
        }

        protected void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
