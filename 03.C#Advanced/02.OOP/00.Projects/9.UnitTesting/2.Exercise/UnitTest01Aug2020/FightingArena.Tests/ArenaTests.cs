namespace Tests
{
    using System.Linq;
    using NUnit.Framework;

    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;
        private const string NAME = "Test";
        private const int DAMAGE = 120;
        private const int HP = 110;
        
        private const string NAME1 = "Test1";
        private const int DAMAGE1 = 100;
        private const int HP1 = 31;

        private Warrior warrior;
        private Warrior enemy;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior(NAME, DAMAGE, HP);
            this.enemy = new Warrior(NAME1, DAMAGE1, HP1);
        }

        [Test]
        public void COnstructorShouldSetTheAraneWarriorListToInstance()
        {
            //Assert
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            var msg = "Warrior is already enrolled for the fights!";

            //Act and Assert
            Assert.That(() => this.arena.Enroll(this.warrior),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void EnrollMethodShouldAddTheWarriorToTheCollectionAndIncreaseCount()
        {
            //Arrange
            var expectedCount = 1;

            //Act
            this.arena.Enroll(this.warrior);
            var enrrolledWarrior = this.arena
                .Warriors
                .First(w => w.Name == NAME);

            //Assert
            Assert.That(this.arena.Count, Is.EqualTo(expectedCount));
            Assert.That(warrior.Name, Is.EqualTo(NAME));
            Assert.That(warrior.Damage, Is.EqualTo(DAMAGE));
            Assert.That(warrior.HP, Is.EqualTo(HP));
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfWarriorNameDoesNotExits()
        {
            //Arrange
            var msg = $"There is no fighter with name {NAME} enrolled for the fights!";

            //Act and Assert
            Assert.That(() => this.arena.Fight(NAME, NAME),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfEnemyNameDoesNotExits()
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            var msg = $"There is no fighter with name {NAME1} enrolled for the fights!";

            //Act and Assert
            Assert.That(() => this.arena.Fight(NAME, NAME1),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FightMethodShouldCallWarriorAttackMethodIfEverythingIsSuccessfull()
        {
            //Arrange
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.enemy);

            //Act
            this.arena.Fight(NAME, NAME1);

            //Assert
            Assert.That(this.warrior.HP, Is.EqualTo(HP - enemy.Damage));
            Assert.That(this.enemy.HP, Is.EqualTo(0));
        }
    }
}
