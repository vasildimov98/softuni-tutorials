namespace Aquariums.Tests
{
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        //Arrange:
        private const string TEST_NAME = "Test name";
        private const int TEST_CAPACITY = 5;

        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium(TEST_NAME, TEST_CAPACITY);
        }

        [Test]
        public void PropertyNameShouldThrowExceptionIfNullOrEmpty()
        {
            //Arrange
            var name = (string)null;

            //Act & Assert
            Assert.That(() => new Aquarium(name, 100),
                Throws.ArgumentNullException
                .With.Message.EqualTo("Invalid aquarium name! (Parameter 'value')"));
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionIfcValueLessThanZero()
        {
            //Arrange
            var capacity = -100;

            //Act & Assert
            Assert.That(() => new Aquarium(TEST_NAME, capacity),
                Throws.ArgumentException
                .With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void ConstructorShouldSetGivenValue()
        {
            //Assert
            Assert.That(this.aquarium, Is.Not.Null);
            Assert.That(this.aquarium.Name, Is.EqualTo(TEST_NAME));
            Assert.That(this.aquarium.Capacity, Is.EqualTo(TEST_CAPACITY));
        }

        [Test]
        public void CountShouldIncreaseWhenFishIsAdded()
        {
            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(0));

            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));

            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(4));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCapacityIsReached()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));
            this.aquarium.Add(new Fish("Pesho5"));

            //Assert
            Assert.That(() => this.aquarium.Add(new Fish("Pesho6")),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void AddMethodShouldAddFishSuccessfully()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));

            var report = this.aquarium.Report();

            //Assert
            Assert.That(report, Is.EqualTo($"Fish available at {this.aquarium.Name}: Pesho1"));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfFishDoesntExist()
        {
            //Arrange
            var name = "Pesho";

            //Act & Assert
            Assert.That(() => this.aquarium.RemoveFish(name),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }

        [Test]
        public void RemoveMethodShouldDecreaseCapacity()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));
            this.aquarium.Add(new Fish("Pesho5"));

            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(5));

            //Act
            this.aquarium.RemoveFish("Pesho1");
            this.aquarium.RemoveFish("Pesho2");
            this.aquarium.RemoveFish("Pesho3");

            //Assert
            Assert.That(this.aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void SellFishMethodShouldThrowExceptionWhenNameNotFound()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));
            this.aquarium.Add(new Fish("Pesho5"));

            var name = "Pesho100";

            //Act & Assert
            Assert.That(() => this.aquarium.SellFish(name),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }

        [Test]
        public void SellFishMethodShouldReturnFish()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));
            this.aquarium.Add(new Fish("Pesho5"));

            var name = "Pesho1";

            //Act
            var soldFish = this.aquarium.SellFish(name);

            //Assert
            Assert.That(soldFish.Name, Is.EqualTo(name));
            Assert.That(soldFish.Available, Is.False);
        }

        [Test]
        public void ReportMethodShouldReturnCorrectReport()
        {
            //Arrange
            this.aquarium.Add(new Fish("Pesho1"));
            this.aquarium.Add(new Fish("Pesho2"));
            this.aquarium.Add(new Fish("Pesho3"));
            this.aquarium.Add(new Fish("Pesho4"));
            this.aquarium.Add(new Fish("Pesho5"));

            var collection = new[]
            {
                "Pesho1",
                "Pesho2",
                "Pesho3",
                "Pesho4",
                "Pesho5"
            };

            string names = string.Join(", ", collection);

            string expectedReport = $"Fish available at {this.aquarium.Name}: {names}";

            // Act
            var report = this.aquarium.Report();

            //Assert
            Assert.That(report, Is.EqualTo(report));
        }
    }
}
