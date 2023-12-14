using Code.Logic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Code.Hero
{
    [AddComponentMenu("Hero/Attack")]
    [RequireComponent(typeof(Gun))]
    public class HeroAttack : MonoBehaviour, IAttack
    {
        public float Damage { get; set; }

        private InputActions _actions;
        private Gun _gun;

        [Inject]
        private void Construct(InputActions actions)
        {
            _actions = actions;
            _gun = GetComponent<Gun>();
        }

        private void OnEnable()
        {
            _actions.Enable();
            _actions.Player.Fire.started += Fire;
            _actions.Player.Fire2.started += Ultimate;
        }

        private void OnDisable()
        {
            _actions.Disable();
            _actions.Player.Fire.started -= Fire;
            _actions.Player.Fire2.started -= Ultimate;
        }

        public void Attack()
        {
            _gun.Shoot();
        }

        private void Fire(InputAction.CallbackContext context)
        {
            Attack();
        }

        private void Ultimate(InputAction.CallbackContext context)
        {
            Debug.Log("Ultimate!");
        }
    }
}