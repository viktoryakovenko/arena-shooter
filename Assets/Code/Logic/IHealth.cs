namespace Code.Logic
{
    public interface IHealth : IUnitState
    {
        void TakeDamage(float amount);
    }
}