namespace Computers.Tests
{
    using NUnit.Framework;
 
    public class ComputerTests
    {
        private const string COMPUTER_NAME = "Test";

        private const string PART_NAME = "Test";
        private const decimal PART_PRICE = 100M;

        private Computer computer;
        private Part part;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer(COMPUTER_NAME);
            this.part = new Part(PART_NAME, PART_PRICE);
        }

        [Test]
        public void NamePropertyShouldThrowExceptionIfNameValueIsNull()
        {
            //Act & Assert
            Assert.That(() => new Computer(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NamePropertyShouldThrowExceptionIfNameIsEmpty()
        {
            //Act & Assert
            Assert.That(() => new Computer(string.Empty),
                Throws.ArgumentNullException);
        }

        [Test]
        public void ConstructorShouldSetTheCorrectValue()
        {
            //Arrange
            var expectedCount = 0;

            //Act & Assert
            Assert.That(this.computer, Is.Not.Null);
            Assert.That(this.computer.Name, Is.EqualTo(COMPUTER_NAME));
            Assert.That(this.computer.Parts.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void TotalPriceShouldReturnZeroIfNoPartsAreAdded()
        {
            //Arrange
            var expectedPrice = 0m;

            //Act & Assert
            Assert.That(this.computer.TotalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void TotalPriceShouldReturnReturnCorrectPrice()
        {
            //Arrange
            var partsToAdd = 5;
            this.AddPartsToComputer(partsToAdd);
            var expectedPrice = PART_PRICE * partsToAdd;

            //Act & Assert
            Assert.That(this.computer.TotalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void AddPartMethodShouldThrowExceptionIfPartIsNull()
        {
            //Act & Assert
            Assert.That(() => this.computer.AddPart(null),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Cannot add null!"));
        }

        [Test]
        public void AddPartMethodShouldAddPartToComputer()
        {
            //Arrange
            this.computer.AddPart(this.part);
            var expectedCount = 1;
            var expectedPart = this.computer.GetPart(PART_NAME);

            //Act
            Assert.That(this.computer.Parts.Count, Is.EqualTo(expectedCount));
            Assert.That(this.part, Is.EqualTo(expectedPart));
        }

        [Test]
        public void RemovePartMethodReturnsFalseIfOperationFailed()
        {
            //Assert
            Assert.That(() => this.computer.RemovePart(this.part), Is.False);
        }

        [Test]
        public void RemovePartMethodReturnsTrueIfOperationWasSuccess()
        {
            //Arrange
            this.computer.AddPart(this.part);

            //Assert
            Assert.That(() => this.computer.RemovePart(this.part), Is.True);
        }

        [Test]
        public void GetPartShouldReturnNullIfNothingFound()
        {
            //Assert
            Assert.That(() => this.computer.GetPart(PART_NAME), Is.Null);
        }

        [Test]
        public void GetPartShouldGetTheRightPart()
        {
            //Arrange
            this.computer.AddPart(this.part);

            //Assert
            Assert.That(() => this.computer.GetPart(PART_NAME), Is.EqualTo(this.part));
        }

        private void AddPartsToComputer(int partsToAdd)
        {
            for (int i = 0; i < partsToAdd; i++)
            {
                this.computer.AddPart(new Part($"{PART_NAME}{i + 1}", PART_PRICE));
            }
        }
    }
}