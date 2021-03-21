namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
        }

        [Test]
        public void CreatedMethodShouldThrowExceptionIfPresentIsNull()
        {
            //Arrange
            Present present = null;

            //Act & Assert
            Assert.That(() => this.bag.Create(present),
                Throws.ArgumentNullException
                .With.Message.EqualTo("Value cannot be null. (Parameter 'Present is null')"));
        }

        [Test]
        public void CreatedMethodShouldThrowExceptionIfPresentExists()
        {
            //Arrange
            Present present = new Present("TestPresent", 100);
            this.bag.Create(present);

            //Act & Assert
            Assert.That(() => this.bag.Create(present),
                Throws.InvalidOperationException
                .With.Message.EqualTo("This present already exists!"));
        }

        [Test]
        public void CreatedMethodShouldReturnStringIfSuccessfullyAdded()
        {
            //Arrange
            Present present = new Present("TestPresent", 100);
            var expectedResult = $"Successfully added present {present.Name}.";

            //Act
            var actualResult = this.bag.Create(present);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveMethodShouldReturnFalseIfNotSuccessgullyRemoved()
        {
            //Arrange
            var bag = new Bag();
            Present present = new Present("TestPresent", 100);
            bag.Create(present);
            var presentToRemoved = new Present("TestPresent1", 100);

            //Act
            var result = this.bag.Remove(presentToRemoved);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfSuccessgullyRemoved()
        {
            //Arrange
            var bag = new Bag();
            Present present = new Present("TestPresent", 100);
            this.bag.Create(present);

            //Act
            var result = this.bag.Remove(present);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldThrowExceptionIfSeqIsEmpty()
        {
            //Act & Assert
            Assert.That(() => this.bag.GetPresentWithLeastMagic(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Sequence contains no elements"));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldTheLeastMagicalOne()
        {
            //Arrange
            this.GetBagFulledWithPresents();

            //Act
            var leastMagOne = this.bag.GetPresentWithLeastMagic();

            //Arrange
            Assert.That(leastMagOne.Name, Is.EqualTo("Test1"));
            Assert.That(leastMagOne.Magic, Is.EqualTo(100));
        }

        [Test]
        public void GetPresentShouldRetunNullIfSeqIsEmpty()
        {
            //Arrange
            this.GetBagFulledWithPresents();
            var nonexistentName = "Test10";

            //Act
            var present = this.bag.GetPresent(nonexistentName);

            //Act & Assert
            Assert.That(present, Is.Null);
        }

        [Test]
        public void GetPresentShouldRetunTherightPresent()
        {
            //Arrange
            this.GetBagFulledWithPresents();
            var existentName = "Test3";
            var magic = 100 * 3;

            //Act
            var present = this.bag.GetPresent(existentName);

            //Act & Assert
            Assert.That(present, Is.Not.Null);
            Assert.That(present.Name, Is.EqualTo(existentName));
            Assert.That(present.Magic, Is.EqualTo(magic));
        }

        [Test]
        public void GetPresentsShouldRetunAllPresents()
        {
            //Arrange
            this.GetBagFulledWithPresents();

            //Act
            var presents = this.bag.GetPresents();
            var expectedResult = this.GetAllPresentsAsReadOnly(presents);

            //Act & Assert
            Assert.That(presents.Count, Is.EqualTo(5));
            CollectionAssert.AreEqual(expectedResult, presents);
        }

        private void GetBagFulledWithPresents()
        {
            for (int i = 0; i < 5; i++)
            {
                var magic = 100 * (i + 1);
                this.bag.Create(new Present($"Test{i + 1}", magic));
            }
        }

        private IReadOnlyCollection<Present> GetAllPresentsAsReadOnly(IReadOnlyCollection<Present> presents)
        {
            var list = new List<Present>(presents);

            return list.AsReadOnly();
        }
    }
}
