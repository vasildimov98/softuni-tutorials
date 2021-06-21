namespace Skeleton.Contracts
{
    public interface ITarget
    {
        int Health { get; }
        void TakeAttack(int damage);
        int GiveExperience();
        bool IsDead();
    }
}
