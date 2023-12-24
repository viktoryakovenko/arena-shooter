using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartScene);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartScene);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
