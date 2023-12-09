using System;

namespace Code.Logic
{
    public interface IUnitState
    {
        event Action StateChanged;

        float Max { get; set; }
        float Current { get; set; }
    }
}
