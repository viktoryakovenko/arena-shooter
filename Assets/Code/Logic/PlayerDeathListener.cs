using Code.Hero;
using UnityEngine;
using Zenject;

namespace Code.Logic
{
    public class PlayerDeathListener : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverCanvas;

        private HeroDeath _heroDeath;

        [Inject]
        private void Construct(HeroMovement heroMovement)
        {
            _heroDeath = heroMovement.GetComponent<HeroDeath>();
        }

        private void OnEnable()
        {
            _gameOverCanvas.SetActive(false);
            _heroDeath.Happened += ShowGameOver;
        }

        private void OnDisable()
        {
            _heroDeath.Happened -= ShowGameOver;
        }

        private void ShowGameOver()
        {
            _gameOverCanvas.SetActive(true);
        }
    }
}