namespace Tests
{
    using NUnit.Framework;

    using FightingArena;

    public class WarriorTests
    {
        private const string NAME = "Test";
        private const int DAMAGE = 30;
        private const int HP = 30;
        private const int MIN_ATTACK_HP = 30;

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(NAME, DAMAGE, HP);
        }

        [Test]
        public void ConstructorShouldSetTheRightValues()
        {
            //Assert
            Assert.That(warrior.Name, Is.EqualTo(NAME));
            Assert.That(warrior.Damage, Is.EqualTo(DAMAGE));
            Assert.That(warrior.HP, Is.EqualTo(HP));
        }

        [Test]
        public void NamePropertyShouldThrowExceptionIfInvalid()
        {
            //Arrange
            var msg = "Name should not be empty or whitespace!";

            //Act and Assert
            Assert.That(() => new Warrior(null, DAMAGE, HP),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void DamagePropertyShouldThrowExceptionIfInvalid()
        {
            //Arrange
            var msg = "Damage value should be positive!";

            //Act and Assert
            Assert.That(() => new Warrior(NAME, -DAMAGE, HP),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void HPPropertyShouldThrowExceptionIfInvalid()
        {
            //Arrange
            var msg = "HP should not be negative!";

            //Act and Assert
            Assert.That(() => new Warrior(NAME, DAMAGE, -HP),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfHPTooLow()
        {
            //Arrange
            var msg = "Your HP is too low in order to attack other warriors!";

            //Act and Assert
            Assert.That(() => this.warrior.Attack(new Warrior(NAME, DAMAGE, HP)),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfHpOfWarriorsThatIsAttackedIsTooLow()
        {
            //Arrange
            var msg = $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!";
            var validHp = 31;

            //Act and Assert
            Assert.That(() => new Warrior(NAME, DAMAGE, validHp).Attack(this.warrior),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfHpOfWarriorsHPIsLessThanDeffenderDamage()
        {
            //Arrange
            var msg = $"You are trying to attack too strong enemy";
            var validHp = 31;

            //Act and Assert
            Assert.That(() => new Warrior(NAME, DAMAGE, validHp).Attack(new Warrior(NAME, DAMAGE * 2, validHp)),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AttackMethodShouldDecreaseHealthOnlyToZero()
        {
            //Arrange
            var validHp = 60;
            var biggerThanHPDamage = 120;
            var warrior = new Warrior(NAME, biggerThanHPDamage, validHp);
            var deffender = new Warrior(NAME, DAMAGE, validHp);

            //Act
            warrior.Attack(deffender);

            //Assert
            Assert.That(deffender.HP, Is.EqualTo(0));
        }
    }
}