namespace Skeleton.Tests.FakeClasses
{
    public class FakeTarget : ITarget
    {
        public int Health { get; }

        public int GiveExperience()
            => 10;

        public bool IsDead()
            => true;

        public void TakeAttack(int attackPoints)
        {
            throw new System.NotImplementedException();
        }
    }
}
