using UnityEngine;
using Zenject;

namespace Code.Hero
{
    [AddComponentMenu("Hero/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    { 
        public float MovementSpeed;

        private InputActions _actions;
        private CharacterController _characterController;

        [Inject]
        private void Construct(InputActions actions)
        {
            _actions = actions;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }

        private void Update()
        {
            Vector2 direction = _actions.Player.Move.ReadValue<Vector2>();
            float scaledMoveSpeed = MovementSpeed * Time.deltaTime;

            Vector3 offset = transform.rotation * new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;

            offset += Physics.gravity;
            _characterController.Move(offset);
        }
    }
}