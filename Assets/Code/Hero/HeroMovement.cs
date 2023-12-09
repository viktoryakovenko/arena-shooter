using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    { 
        private float _movementSpeed;
        private InputActions _actions;
        private CharacterController _characterController;

        [Inject]
        private void Construct(InputActions actions, HeroStaticData staticData)
        {
            _actions = actions;
            _movementSpeed = staticData.MoveSpeed;
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
            float scaledMoveSpeed = _movementSpeed * Time.deltaTime;

            Vector3 offset = transform.rotation * new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;

            offset += Physics.gravity;
            _characterController.Move(offset);
        }
    }
}