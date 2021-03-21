using NUnit.Framework;
using Skeleton.Tests.FakeClasses;

[TestFixture]
public class HeroTests
{
    [Test]
    public void ExperienceShouldInCreaseIfTargetIsDead()
    {
        // Arrange
        var name = "Pesho";
        
        var fakeWeapon = new FakeWeapon();
        var fakeTarget = new FakeTarget();

        var hero = new Hero(name, fakeWeapon);

        var expectedResult = 10;

        // Act
        hero.Attack(fakeTarget);

        // Assert
        Assert.That(hero.Experience, Is.EqualTo(expectedResult));
    }
}