namespace Tests.Fake
{
    public class FakeTarget : ITarget
    {
        public const int DEFAULT_EXPERIENCE = 100;
        public int Health { get; private set; }

        public int GiveExperience() => DEFAULT_EXPERIENCE;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
