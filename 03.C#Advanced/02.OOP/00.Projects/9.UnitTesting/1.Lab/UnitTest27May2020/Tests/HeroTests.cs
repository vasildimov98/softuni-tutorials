namespace Tests
{
    using NUnit.Framework;
    using Tests.Fake;

    [TestFixture]
    public class HeroTests
    {
        private const int EXPERIENCE = 100;
        [Test]
        public void HeroShouldGainExperienceWhenTargerIsDead()
        {
            //Arrange
            var target = new FakeTarget();
            var weapon = new FakeWeapon();
            var hero = new Hero("TestHero", weapon);

            //Act
            hero.Attack(target);

            //Assert
            Assert.That(hero.Experience, Is.EqualTo(EXPERIENCE));
        }
    }
}
