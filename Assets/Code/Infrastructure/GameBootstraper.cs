using Code.Infrastructure.States;
using Code.Logic;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(_curtain));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}