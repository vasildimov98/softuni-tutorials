namespace Tests
{
    //using FightingArena;
    using NUnit.Framework;

    public class ArenaTests
    {
        private const string ATTACKER_NAME = "Pesho the Greatest";
        private const string DEFENDER_NAME = "Ivan the Greatest";

        private const int ATTACKER_DAMAGE = 100;
        private const int DEFENDER_DAMAGE = 80;

        private const int ATTACKER_HP = 200;
        private const int DEFENDER_HP = 220;

        private Warrior attacker;
        private Warrior defender;

        private Arena arena;

        [SetUp]
        public void Setup()
        {
            //Arrange
            this.arena = new Arena();
            this.attacker = new Warrior(ATTACKER_NAME, ATTACKER_DAMAGE, ATTACKER_HP);
            this.defender = new Warrior(DEFENDER_NAME, DEFENDER_DAMAGE, DEFENDER_HP);
        }

        [Test]
        public void ConstructorShouldInitializeTheWarriors()
        {
            //Assert
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfWarriorAlreadyExists()
        {
            //Act
            this.arena.Enroll(this.attacker);

            //Assert
            Assert.That(() => this.arena.Enroll(this.attacker),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void EnrollMethodShoudlIncreaseCount()
        {
            //Act
            this.arena.Enroll(this.attacker);

            //Assert
            Assert.That(this.arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void FightMethodShoudlThrowExceptionIfAttackerIsMissing()
        {
            //Act
            this.arena.Enroll(this.defender);

            //Assert
            Assert.That(() => this.arena.Fight(ATTACKER_NAME, DEFENDER_NAME),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"There is no fighter with name {ATTACKER_NAME} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShoudlThrowExceptionIfDefenderIsMissing()
        {
            //Act
            this.arena.Enroll(this.attacker);

            //Assert
            Assert.That(() => this.arena.Fight(ATTACKER_NAME, DEFENDER_NAME),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"There is no fighter with name {DEFENDER_NAME} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShouldBeAbleToPassTheAttackCommandOnWarriors()
        {
            //Act
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            //Act
            this.arena.Fight(ATTACKER_NAME, DEFENDER_NAME);

            //Assert
            Assert.That(this.attacker.HP, Is.EqualTo(ATTACKER_HP - DEFENDER_DAMAGE));
            Assert.That(this.defender.HP, Is.EqualTo(DEFENDER_HP - ATTACKER_DAMAGE));
        }
    }
}
