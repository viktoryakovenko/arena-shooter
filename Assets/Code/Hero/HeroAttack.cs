using Code.StaticData;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class HeroAttack : MonoBehaviour
{
    private InputActions _actions;
    private float _damage;

    [Inject]
    private void Construct(InputActions actions, HeroStaticData staticData)
    {
        _actions = actions;
        _damage = staticData.Damage;
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Fire.started += Attack;
        _actions.Player.Fire2.started += Ultimate;
    }


    private void OnDisable()
    {
        _actions.Disable();
        _actions.Player.Fire.started -= Attack;
        _actions.Player.Fire2.started -= Ultimate;
    }
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log(_damage);
    }

    private void Ultimate(InputAction.CallbackContext context)
    {
        Debug.Log("Ultimate!");
    }

}
