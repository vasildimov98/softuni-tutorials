namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class AquariumsTests
    {
        //Arrange
        private const string NAME = "Test";
        private const int CAPACITY = 5;

        private Aquarium aquarium;

        //Act
        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium(NAME, CAPACITY);
        }

        [Test]
        public void ConstructorShouldSetValuesCorrecltly()
        {
            //Assert
            Assert.That(this.aquarium, Is.Not.Null);
            Assert.That(this.aquarium.Name, Is.EqualTo(NAME));
            Assert.That(this.aquarium.Capacity, Is.EqualTo(CAPACITY));
        }

        [Test]
        public void NamePropertyShouldThrowExceptionIdNameIsEmptyOrNull()
        {
            //Act and Assert
            Assert.That(() => new Aquarium(null, CAPACITY),
                Throws.ArgumentNullException);
            Assert.That(() => new Aquarium(string.Empty, CAPACITY),
                 Throws.ArgumentNullException);
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionIfValueIsNegative()
        {
            //Arrange
            var capacity = -100;
            var msg = "Invalid aquarium capacity!";

            //Act and Assert
            Assert.That(() => new Aquarium(NAME, capacity),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAquariumIsFull()
        {
            //Arrange
            var count = 5;
            this.AddFisheshToAquarium(count);
            var msg = "Aquarium is full!";

            //Assert
            Assert.That(() => this.aquarium.Add(new Fish(NAME)),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldIncreaseCountWhenSuccessfullyAddsFish()
        {
            //Arrange
            var count = 5;
            this.AddFisheshToAquarium(count);

            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(count));
        }

        [Test]
        public void RemoveMethodShouldThrowExcpetionIfFishIsNotPresent()
        {
            //Arrange
            var count = 5;
            this.AddFisheshToAquarium(count);
            var msg = $"Fish with the name {NAME} doesn't exist!";

            //Assert
            Assert.That(() => this.aquarium.RemoveFish(NAME),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void RemoveMethodShouldDecreaseCountWhenMethodIsSuccessfull()
        {
            //Arrange
            var count = 5;
            var expectedCount = 3;
            this.AddFisheshToAquarium(count);
            var msg = $"Fish with the name {NAME} doesn't exist!";

            //Act
            this.aquarium.RemoveFish(NAME + 1);
            this.aquarium.RemoveFish(NAME + 2);

            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void SellFishMethodShouldThrowExcpetionIfFishIsNotPresent()
        {
            //Arrange
            var count = 5;
            this.AddFisheshToAquarium(count);
            var msg = $"Fish with the name {NAME} doesn't exist!";

            //Assert
            Assert.That(() => this.aquarium.SellFish(NAME),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void SellFishMethodShouldReturnTheSameFishAndTheFishShouldBeUnavailable()
        {
            //Arrange
            var expectedFish = new Fish(NAME);
            this.aquarium.Add(expectedFish);

            //Act
            var actualFish = aquarium.SellFish(NAME);

            //Assert
            Assert.That(expectedFish, Is.EqualTo(actualFish));
            Assert.That(actualFish.Available, Is.False);
            Assert.That(expectedFish.Available, Is.False);
        }

        [Test]
        public void ReportShouldReturnTheExpectedResult()
        {
            //Arrange 
            var list = new List<string>()
            {
                NAME + 1,
                NAME + 2,
                NAME + 3,
                NAME + 4,
                NAME + 5,
            };

            var fishNames = string.Join(", ", list);

            var expectedReport = $"Fish available at {this.aquarium.Name}: {fishNames}";

            var count = 5;
            this.AddFisheshToAquarium(count);

            //Act
            var actualReport = this.aquarium.Report();

            //Assert
            Assert.That(expectedReport, Is.EqualTo(actualReport));
        }

        private void AddFisheshToAquarium(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                this.aquarium.Add(new Fish(NAME + i));
            }
        }
    }
}
