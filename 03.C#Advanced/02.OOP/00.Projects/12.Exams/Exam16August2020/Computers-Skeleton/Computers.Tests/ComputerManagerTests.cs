namespace Computers.Tests
{
    using NUnit.Framework;
    using System.Collections.ObjectModel;

    public class Tests
    {
        private const string CanNotBeNullMessage = "Can not be null!";

        private const string MANUFACTURAR = "TEST1";
        private const string MODEL = "TEST1";
        private const decimal PRICE = 5.60m;

        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer(MANUFACTURAR, MODEL, PRICE);
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ConstructorShouldSetTheCorrectValue()
        {
            //Arrange
            var computer = new Computer(MANUFACTURAR, MODEL, PRICE);
            var computerManager = new ComputerManager();

            //Assert
            Assert.That(computerManager, Is.Not.Null);
            Assert.That(computerManager.Computers, Is.Not.Null);
            Assert.That(computerManager.Computers.GetType().Name, Is.EqualTo(typeof(ReadOnlyCollection<Computer>).Name));
            Assert.That(computer.Manufacturer, Is.EqualTo(MANUFACTURAR));
            Assert.That(computer.Model, Is.EqualTo(MODEL));
            Assert.That(computer.Price, Is.EqualTo(PRICE));
        }

        [Test]
        public void AddComputerShouldThrowExceptionIfValueIsNull()
        {
            //Arrange
            var invalidNullComputer = (Computer)null;
            var msg = $"{CanNotBeNullMessage} (Parameter 'computer')";

            //Assert
            Assert.That(() => this.computerManager.AddComputer(invalidNullComputer),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddComputerShouldThrowExceptionIfYouTryToAddTheSameComuterComputer()
        {
            //Arrange
            this.computerManager.AddComputer(this.computer);
            var msg = "This computer already exists.";

            //Assert
            Assert.That(() => this.computerManager.AddComputer(this.computer),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddComputerShouldIncreaseCountIfMethodIsSuccessfull()
        {
            //Arrange and Assert
            var firstExpectedCount = 0;
            Assert.That(this.computerManager.Count, Is.EqualTo(firstExpectedCount));

            //Arrange
            var computerToAdd = 5;
            this.AddComputersToComputerManager(computerToAdd);
            var secondExpectedCount = computerToAdd;

            //Assert  
            Assert.That(this.computerManager.Count, Is.EqualTo(secondExpectedCount));
        }

        [Test]
        public void RemoveComputerShouldThrowExceptionIfManufacturerIsNull()
        {
            //Arrange
            var msg = $"{CanNotBeNullMessage} (Parameter 'manufacturer')";

            //Assert
            Assert.That(() => this.computerManager.RemoveComputer(null, MODEL),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void RevoveComputerShouldThrowExceptionIfModelIsNull()
        {
            //Arrange
            var msg = $"{CanNotBeNullMessage} (Parameter 'model')";

            //Assert
            Assert.That(() => this.computerManager.RemoveComputer(MANUFACTURAR, null),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void RemoveComputerShouldRemoveTheRightComputerAndReturnIt()
        {
            //Arrange
            this.computerManager.AddComputer(this.computer);

            //Act
            var actualComputer = this.computerManager.RemoveComputer(MANUFACTURAR, MODEL);

            //Assert
            Assert.That(actualComputer, Is.EqualTo(this.computer));
            Assert.That(actualComputer.Manufacturer, Is.EqualTo(MANUFACTURAR));
            Assert.That(actualComputer.Model, Is.EqualTo(MODEL));
            Assert.That(actualComputer.Price, Is.EqualTo(PRICE));
        }

        [Test]
        public void GetComputerShouldThrowExceptionIfManufacturerIsNull()
        {
            //Arrange
            var msg = $"{CanNotBeNullMessage} (Parameter 'manufacturer')";

            //Assert
            Assert.That(() => this.computerManager.GetComputer(null, MODEL),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void GetComputerShouldThrowExceptionIfModelIsNull()
        {
            //Arrange
            var msg = $"{CanNotBeNullMessage} (Parameter 'model')";

            //Assert
            Assert.That(() => this.computerManager.GetComputer(MANUFACTURAR, null),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void GetComputerShouldThrowExceptionIfThereIsNoSuchComputer()
        {
            //Arrange
            var msg = "There is no computer with this manufacturer and model.";

            //Act and Assert
            Assert.That(() => this.computerManager.GetComputer(MANUFACTURAR, MODEL), Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void GetComputerShouldReturnTheRightComputer()
        {
            //Arrange
            this.computerManager.AddComputer(this.computer);

            //Act
            var actualComputer = this.computerManager.GetComputer(MANUFACTURAR, MODEL);

            //Assert
            Assert.That(actualComputer, Is.EqualTo(this.computer));
            Assert.That(actualComputer.Manufacturer, Is.EqualTo(MANUFACTURAR));
            Assert.That(actualComputer.Model, Is.EqualTo(MODEL));
            Assert.That(actualComputer.Price, Is.EqualTo(PRICE));
        }

        [Test]
        public void GetComputersByManufacturerShouldThrowExceptionIfManufacturerIsNulll()
        {
            //Arrange
            var msg = $"{CanNotBeNullMessage} (Parameter 'manufacturer')";

            //Assert
            Assert.That(() => this.computerManager.GetComputersByManufacturer(null),
                Throws.ArgumentNullException.With.Message.EqualTo(msg));
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnEmptyCollectionIfThereIsNoSuchManufacturer()
        {
            //Act
            var actualExpectedCollection = this.computerManager.GetComputersByManufacturer(MANUFACTURAR);

            //Assert
            Assert.That(actualExpectedCollection, Is.Empty);
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnCollectionWithTheGivenManufacturer()
        {
            //Arrange
            var comuterToAdd = 5;
            this.AddComputersToComputerManager(5);

            //Act
            var actualExpectedCollection = this.computerManager.GetComputersByManufacturer(MANUFACTURAR);

            //Assert
            Assert.That(actualExpectedCollection, Is.Not.Empty);
            Assert.That(actualExpectedCollection.Count, Is.EqualTo(comuterToAdd));
        }

        private void AddComputersToComputerManager(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                this.computerManager.AddComputer(new Computer(MANUFACTURAR, MODEL + i, PRICE));
            }
        }
    }
}