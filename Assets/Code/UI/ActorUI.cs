using Code.Logic;
using UnityEngine;

namespace Code.UI
{
    public class ActorUI<TState> : MonoBehaviour where TState : IUnitState
    {
        public StatBar Bar;

        private TState _state;

        public void Construct(TState state)
        {
            _state = state;

            UpdateBar();

            _state.StateChanged += UpdateBar;
        }

        private void OnDisable()
        {
            _state.StateChanged -= UpdateBar;
        }

        private void UpdateBar() => 
            Bar.SetValue(_state.Current, _state.Max);
    }
}