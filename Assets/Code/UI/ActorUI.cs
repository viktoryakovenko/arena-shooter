using Code.Logic;
using UnityEngine;

namespace Code.UI
{
    public class ActorUI<TState> : MonoBehaviour where TState : IUnitState 
    {
        public StatBar Bar;
        public TState State;

        private void Start()
        {
            UpdateBar();
            State.StateChanged += UpdateBar;
        }

        private void OnDisable()
        {
            State.StateChanged -= UpdateBar;
        }

        private void UpdateBar() => 
            Bar.SetValue(State.Current, State.Max);
    }
}