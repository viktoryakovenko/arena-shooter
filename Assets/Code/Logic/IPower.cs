namespace Code.Logic
{
    public interface IPower : IUnitState
    {
        void AddPower(float amount);
        void RemovePower(float amount);
    }
}