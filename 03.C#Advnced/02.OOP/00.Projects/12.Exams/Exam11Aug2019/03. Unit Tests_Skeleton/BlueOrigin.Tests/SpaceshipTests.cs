namespace BlueOrigin.Tests
{
    using NUnit.Framework;
    using System;

    public class SpaceshipTests
    {
        //Arrange
        private const string TEST_NAME = "Test";
        private const int TEST_CAPACITY = 5;

        private Spaceship spaceship;
        [SetUp]
        public void SetUp()
        {
            spaceship = new Spaceship(TEST_NAME, TEST_CAPACITY);
        }

        [Test]
        public void NamePropertyShouldThrowExceptionIfValueIsNull()
        {
            //Arrange, Act & Assert
            Assert.That(() => new Spaceship(null, 10),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionIfValueIsLessThanZero()
        {
            //Arrange, Act & Assert
            Assert.That(() => new Spaceship("Test", -10),
                Throws.ArgumentException
                .With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void ConstructorShouldSetCapacity()
        {
            //Assert
            Assert.That(this.spaceship.Name, Is.EqualTo(TEST_NAME));
            Assert.That(this.spaceship.Capacity, Is.EqualTo(TEST_CAPACITY));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfSpaceshipIsFull()
        {
            //Arrange
            var countOfAstronauts = 5;
            this.GetSpaceShipFullWith(countOfAstronauts);

            //Act & Assert
            Assert.That(() => this.spaceship.Add(new Astronaut("Test6", 100)),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Spaceship is full!"));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAstronautExitst()
        {
            //Arrange
            var countOfAstronauts = 4;
            this.GetSpaceShipFullWith(countOfAstronauts);

            //Act & Assert
            Assert.That(() => this.spaceship.Add(new Astronaut("Test3", 100)),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Astronaut Test3 is already in!"));
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(0));

            //Arrange
            var countOfAstronauts = 3;
            this.GetSpaceShipFullWith(countOfAstronauts);

            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(countOfAstronauts));
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            //Arrange
            var countOfAstronauts = 3;
            var expectedCountAfterRemoved = 1;
            this.GetSpaceShipFullWith(countOfAstronauts);

            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(countOfAstronauts));

            //Act
            var isRemoved1 = this.spaceship.Remove("Test1");
            var isRemoved2 = this.spaceship.Remove("Test2");

            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(expectedCountAfterRemoved));
            Assert.That(isRemoved1, Is.True);
            Assert.That(isRemoved2, Is.True);
        }

        [Test]
        public void RemoveMethodShouldReturnBoolean()
        {
            //Arrange
            var countOfAstronauts = 3;
            var expectedCountAfterRemoved = 3;
            this.GetSpaceShipFullWith(countOfAstronauts);

            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(countOfAstronauts));

            //Act
            var isRemoved1 = this.spaceship.Remove("Test5");
            var isRemoved2 = this.spaceship.Remove("Test6");

            //Assert
            Assert.That(this.spaceship.Count, Is.EqualTo(expectedCountAfterRemoved));
            Assert.That(isRemoved1, Is.False);
            Assert.That(isRemoved2, Is.False);
        }

        private void GetSpaceShipFullWith(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.spaceship.Add(new Astronaut($"{TEST_NAME}{i + 1}", 100));
            }
        }
    }
}