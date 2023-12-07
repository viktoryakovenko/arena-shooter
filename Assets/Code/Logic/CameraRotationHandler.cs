using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _sensitivity = 50f;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private float _minVerticalAngle = -30f;
    [SerializeField] private float _maxVerticalAngle = 30f;

    private float _horizontal = 0f;
    private float _vertical = 0f;
    private InputActions _actions;

    [Inject]
    private void Construct(InputActions actions)
    {
        _actions = actions;
    }

    private void Start()
    {
        _actions.Player.Rotation.performed += Rotate;
    }

    private void OnDestroy()
    {
        _actions.Player.Rotation.performed -= Rotate;
    }

    private void Rotate(InputAction.CallbackContext context)
    {
        var delta = context.action.ReadValue<Vector2>();
        var deltaTime = Time.deltaTime;

        _vertical -= _sensitivity * delta.y * deltaTime;
        _horizontal += _sensitivity * delta.x * deltaTime;

        gameObject.transform.eulerAngles = new Vector3(0f, _horizontal, 0f);

        _vertical = Mathf.Clamp(_vertical, _minVerticalAngle, _maxVerticalAngle);
        _rotationTarget.eulerAngles = new Vector3(_vertical, _horizontal, 0f);
    }

}
