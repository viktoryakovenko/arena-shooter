using Code.Logic;
using UnityEngine;

namespace Code.UI
{
    public class ActorUI : MonoBehaviour
    {
        public StatBar Bar;

        private IUnitState _state;

        public void Construct(IUnitState state)
        {
            _state = state;

            _state.StateChanged += UpdateBar;

            UpdateBar();
        }

        private void OnDestroy()
        {
            _state.StateChanged -= UpdateBar;
        }

        private void UpdateBar() => 
            Bar.SetValue(_state.Current, _state.Max);
    }
}