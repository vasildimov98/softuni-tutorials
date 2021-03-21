namespace ParkingSystem.Tests
{
    using NUnit.Framework;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car car;


        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            car = new Car("VW", "CR1213");
        }

        [Test]
        public void ConstructorShouldInstantiateDictionaryWithKVP()
        {
            //Arrange
            var nullCollection
                = new Car[] { null, null, null, null, null, null, null, null, null, null, null, null };

            //Act & Assert
            Assert.That(this.softPark.Parking.Count, Is.EqualTo(12));
            Assert.That(this.softPark.Parking.Values, Is.EqualTo(nullCollection));
            Assert.That(this.softPark.Parking.ContainsKey("A4"), Is.EqualTo(true));
            Assert.That(this.softPark.Parking.ContainsKey("F4"), Is.EqualTo(false));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfSpotDoesntExists()
        {
            //Act & Assert
            Assert.That(() => this.softPark.ParkCar("H12", car),
                Throws.ArgumentException
                .With.Message.EqualTo("Parking spot doesn't exists!"));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfSpotTaken()
        {
            //Arrange
            this.softPark.ParkCar("B2", car);

            //Act & Assert
            Assert.That(() => this.softPark.ParkCar("B2", new Car("BMW", "CRS23123")),
                Throws.ArgumentException
                .With.Message.EqualTo("Parking spot is already taken!"));
        }

        [Test]
        public void ParkCarShouldThrowExceptionIfRegisterNumberExists()
        {
            //Arrange
            this.softPark.ParkCar("B2", car);

            //Act & Assert
            Assert.That(() => this.softPark.ParkCar("A3", car),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Car is already parked!"));
        }

        [Test]
        public void ParkCarShouldReturnStringIfEverythingWasSuccessfull()
        {
            //Arrange
            var expectedMsg = $"Car:{this.car.RegistrationNumber} parked successfully!";

            //Act
            var actual = this.softPark.ParkCar("A3", car);

            //Assert
            Assert.That(this.softPark.Parking["A3"], Is.EqualTo(this.car));
            Assert.That(actual, Is.EqualTo(expectedMsg));
        }

        [Test]
        public void RemoveCarShouldThrowExceptionIfSpotDoesntExists()
        {
            //Act & Assert
            Assert.That(() => this.softPark.RemoveCar("H12", car),
                Throws.ArgumentException
                .With.Message.EqualTo("Parking spot doesn't exists!"));
        }

        [Test]
        public void RemoveCarShouldThrowExceptionIfCarIsNotTheSame()
        {
            //Arrange
            this.softPark.ParkCar("A1", this.car);
            var secondCar = new Car("BMW", "VV1123d");
            this.softPark.ParkCar("A2", secondCar);

            //Act & Assert
            Assert.That(() => this.softPark.RemoveCar("A2", car),
                Throws.ArgumentException
                .With.Message.EqualTo("Car for that spot doesn't exists!"));
        }

        [Test]
        public void RemoveCarShouldReturnStringIfEverythingWasSuccessfull()
        {
            //Arrange
            this.softPark.ParkCar("A3", car);
            this.softPark.ParkCar("A4", new Car("BMW", "23231"));
            var expectedMsg = $"Remove car:{car.RegistrationNumber} successfully!";

            //Act
            var actual = this.softPark.RemoveCar("A3", car);

            //Assert
            Assert.That(this.softPark.Parking["A3"], Is.EqualTo(null));
            Assert.That(actual, Is.EqualTo(expectedMsg));
        }
    }
}