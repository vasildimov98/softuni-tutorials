namespace Tests.Fake
{
    using Skeleton.Contracts;
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; private set; }

        public void Attack(ITarget target)
        {
        }
    }
}
