namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int INITIAL_ALIVE_DUMMY_HEALTH = 10;
        private const int INITIAL_DEAD_DUMMY_EXPERIENCE = 10;
        private const int DUMMY_TAKE_ATTACK = 10;
        private Dummy aliveDummy;
        private Dummy deadDummy;
        [SetUp]
        public void TestInit()
        {
            this.aliveDummy = new Dummy(INITIAL_ALIVE_DUMMY_HEALTH, INITIAL_DEAD_DUMMY_EXPERIENCE);
           this.deadDummy = new Dummy(0, INITIAL_DEAD_DUMMY_EXPERIENCE);
        }
        [Test]
        public void DummyShouldLoseHealthIfAttack()
        {
            //Act
            this.aliveDummy.TakeAttack(DUMMY_TAKE_ATTACK);

            //Assert
            Assert.That(this.aliveDummy.Health, Is.EqualTo(0));
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttack()
        {
            //Act and Assert
            Assert.That(() => this.deadDummy.TakeAttack(DUMMY_TAKE_ATTACK),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyShouldGiveExpirience()
        {
            //Act
            var experience = this.deadDummy.GiveExperience();

            //Assert
            Assert.That(experience, Is.EqualTo(INITIAL_DEAD_DUMMY_EXPERIENCE));
        }

        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            //Act and Assert
            Assert.That(() => this.aliveDummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
        }
    }
}
