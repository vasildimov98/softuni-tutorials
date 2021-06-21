namespace Tests
{
    //using FightingArena;
    using NUnit.Framework;

    public class WarriorTests
    {
        private const string WARRIOR_NAME = "Pesho the Greatest";
        private const string ENEMY_NAME = "Ivan the Greatest";

        private const int WARRIOR_DAMAGE = 100;
        private const int WARRIOR_HP = 200;
        private const int MIN_ATTACK_HP = 30;

        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(WARRIOR_NAME, WARRIOR_DAMAGE, WARRIOR_HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NamePropertyCannotBeNullOrEmpty(string name)
        {
            //Act and Assert
            Assert.That(() => new Warrior(name, WARRIOR_DAMAGE, WARRIOR_HP),
                Throws.ArgumentException
                .With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        public void DamagePropertyCannotBeZeroOrLess(int damage)
        {
            //Act and Assert
            Assert.That(() => new Warrior(WARRIOR_NAME, damage, WARRIOR_HP),
                Throws.ArgumentException
                .With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HPPropertyCannotBeNegative()
        {
            //Act and Assert
            Assert.That(() => new Warrior(WARRIOR_NAME, WARRIOR_DAMAGE, -WARRIOR_HP),
                Throws.ArgumentException
                .With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void ConstructorShouldGetAndSetAllProperties()
        {
            //Assert
            Assert.That(this.warrior.Name, Is.EqualTo(WARRIOR_NAME));
            Assert.That(this.warrior.Damage, Is.EqualTo(WARRIOR_DAMAGE));
            Assert.That(this.warrior.HP, Is.EqualTo(WARRIOR_HP));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfOwnHPIsLessThanMin()
        {
            //Arrange
            var enemy = new Warrior(ENEMY_NAME, WARRIOR_DAMAGE, MIN_ATTACK_HP);

            //Act and Assert
            Assert.That(() => enemy.Attack(this.warrior),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfEnemyHPIsLessThanMin()
        {
            //Arrange
            var enemy = new Warrior(ENEMY_NAME, WARRIOR_DAMAGE, MIN_ATTACK_HP);

            //Act and Assert
            Assert.That(() => this.warrior.Attack(enemy),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfWarriorsAttackStongerEnemy()
        {
            //Arrange
            var enemy = new Warrior(ENEMY_NAME, WARRIOR_DAMAGE * 3, WARRIOR_HP);

            //Act and Assert
            Assert.That(() => this.warrior.Attack(enemy),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackMethodShouldDecreaseEnemHPAfterEveryAttack()
        {
            //Arrange
            var enemyDamage = 150;
            var enemyHP = 120;
            var enemy = new Warrior(ENEMY_NAME, enemyDamage, enemyHP);

            //Act
            this.warrior.Attack(enemy);

            //Assert
            Assert.That(this.warrior.HP, Is.EqualTo(WARRIOR_HP - enemyDamage));
            Assert.That(enemy.HP, Is.EqualTo(enemyHP - WARRIOR_DAMAGE));
        }

        [Test]
        public void AttackMethodShouldKillEnemyIfDamageIsGreaterThanEnemyHP()
        {
            //Arrange
            var enemyDamage = 150;
            var enemyHP = 80;
            var enemy = new Warrior(ENEMY_NAME, enemyDamage, enemyHP);

            //Act
            this.warrior.Attack(enemy);

            //Assert
            Assert.That(this.warrior.HP, Is.EqualTo(WARRIOR_HP - enemyDamage));
            Assert.That(enemy.HP, Is.EqualTo(0));
        }
    }
}