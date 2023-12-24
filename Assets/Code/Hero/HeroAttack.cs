using Code.Hero.Skills;
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
        private ISkill _skill;

        [Inject]
        private void Construct(InputActions actions)
        {
            _actions = actions;
        }

        private void Start()
        {
            _gun = GetComponent<Gun>();
            _skill = GetComponent<ISkill>();
        }

        private void OnEnable()
        {
            _actions.Player.Fire.started += Fire;
            _actions.Player.Fire2.started += Ultimate;
        }

        private void OnDisable()
        {
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
            _skill.Use();
        }
    }
}