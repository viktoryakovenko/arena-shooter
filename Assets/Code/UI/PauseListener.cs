using Code.Hero;
using Code.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PauseListener : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;

    private bool _isPaused = false;
    private InputActions _inputActions;
    private GameObject _hero;

    [Inject]
    private void Construct(InputActions inputActions, HeroMovement heroMovement)
    {
        _pauseCanvas.SetActive(_isPaused);

        _hero = heroMovement.gameObject;

        _inputActions = inputActions;
        _inputActions.Player.Pause.started += Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0.0f : 1.0f;
        _pauseCanvas.SetActive(_isPaused);

        if (_isPaused)
        {
            _hero.GetComponent<HeroAttack>().enabled = false;
            _hero.GetComponent<CameraRotationHandler>().enabled = false;
        }
        else
        {
            _hero.GetComponent<HeroAttack>().enabled = true;
            _hero.GetComponent<CameraRotationHandler>().enabled = true;
        }
    }
}
