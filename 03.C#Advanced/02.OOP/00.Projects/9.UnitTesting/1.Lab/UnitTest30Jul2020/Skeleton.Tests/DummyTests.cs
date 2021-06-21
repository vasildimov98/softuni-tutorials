using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Dummy deadDummy;

    private const int  HEALTH = 100;
    private const int ZERO_HEATH = 0;
    private const int  EXPERIENCE = 10;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(HEALTH, EXPERIENCE);
        this.deadDummy = new Dummy(ZERO_HEATH, EXPERIENCE);
    }

    [Test]
    public void TakeAttackMethodShouldThrowExceptionIfDummyIsAlreadyDead()
    {
        // Arrange
        var attackedPoints = 10;

        var expectedMsg = "Dummy is dead.";

        // Act and Assert
        Assert.That(() => this.deadDummy.TakeAttack(attackedPoints), 
            Throws.InvalidOperationException.With.Message.EqualTo(expectedMsg),
            "Should throw InvalidOperationException!");
    }

    [Test]
    public void TakeAttackMethodShouldTakeHealthFromDummyIfSuccessful()
    {
        // Arrange
        var attackedPoints = 10;

        var expectedHealth = this.dummy.Health - attackedPoints;

        // Act
        this.dummy.TakeAttack(attackedPoints);

        // Assert
        Assert.That(dummy.Health, Is.EqualTo(expectedHealth),
            "Method should decrease health!");
    }

    [Test]
    public void GiveExperienceShouldThrowExceptionIfDummyStillAlive()
    {
        // Arrange
        var expectedMsg = "Target is not dead.";

        // Act and Assert
        Assert.That(() => this.dummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo(expectedMsg),
            "Should throw InvalidOperationException!");
    }

    [Test]
    public void GiveExperienceShoudlReturnExperienceIfSuccessfull()
    {
        // Act
        var actualExp = this.deadDummy.GiveExperience();

        // Assert
        Assert.That(actualExp, Is.EqualTo(EXPERIENCE));
    }
}
