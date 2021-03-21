namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        
        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //Arrange
            var axe = new Axe(10, 10);

            //Act
            axe.Attack(this.dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9),
                "Durability points doesn't change after attack!");
        }
        [Test]
        public void AxeShouldThrowInvalidOperationExeptionIfItsBroken()
        {
            //Arrange
            var axe = new Axe(10, 0);

            //Assert
            Assert.That(() => axe.Attack(this.dummy),
                 Throws.InvalidOperationException //Act
                 .With.Message.EqualTo("Axe is broken."));
        }
    }
}
