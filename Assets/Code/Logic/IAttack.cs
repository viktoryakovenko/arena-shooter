namespace Code.Logic
{
    public interface IAttack
    {
        float Damage { get; set; }
        void Attack();
    }
}