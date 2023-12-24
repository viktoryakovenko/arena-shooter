using Code.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        private TotalScore _score;

        [Inject]
        private void Construct(TotalScore totalScore)
        {
            _score = totalScore;
        }

        private void OnEnable()
        {
            _scoreText.text = $"Current score : {_score.CurrentScore}";
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
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}