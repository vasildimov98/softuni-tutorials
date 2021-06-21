using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Dummy target;

    private const int HEALTH = 10;
    private const int EXPERIENCE = 10;

    [SetUp]
    public void SetUp()
    {
        this.target = new Dummy(HEALTH, EXPERIENCE);
    }

    [Test]
    public void BrokenAxeCannotAttack()
    {
        // Arrange
        var attack = 10;
        var durability = -12;

        var msg = "Axe is broken.";

        var axe = new Axe(attack, durability);

        // Act and Assert
        Assert.That(() => axe.Attack(this.target),
            Throws.InvalidOperationException.With.Message.EqualTo(msg)
            , "Should throw InvalidOperationException!");
    }

    [Test]
    public void AxeShouldLooseDurabilityAfterSuccessfulAttack()
    {
        // Arrange
        var attack = 10;
        var durability = 12;

        var axe = new Axe(attack, durability);

        var expectedResult = durability - 1;

        // Act
        axe.Attack(this.target);

        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedResult),
            $"Should be equal to {expectedResult}");
    }
}