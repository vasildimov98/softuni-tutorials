namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    public class CarTests
    {
        private const string CAR_MAKE = "Audi";
        private const string CAR_MODEL = "Q7";

        private const double CAR_FUEL_CONSUMPTION = 5;
        private const double CAR_FUEL_CAPACITY = 100;
        private const double CAR_FUEL_TO_REFUEL = 150;

        private Car audiCar;
        [SetUp]
        public void Setup()
        {
            //Arrange
            this.audiCar = new Car(CAR_MAKE, CAR_MODEL, CAR_FUEL_CONSUMPTION, CAR_FUEL_CAPACITY);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyMakeShouldThrowExeptionIfNullOrEmpty(string make)
        {
            //Act and Assert
            Assert.That(() => new Car(make, CAR_MODEL, CAR_FUEL_CONSUMPTION, CAR_FUEL_CAPACITY),
                Throws.ArgumentException
                .With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyModelShouldThrowExeptionIfNullOrEmpty(string model)
        {
            //Act and Assert
            Assert.That(() => new Car(CAR_MAKE, model, CAR_FUEL_CONSUMPTION, CAR_FUEL_CAPACITY),
                Throws.ArgumentException
                .With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void PropertyFuelConsumptionShouldThrowExceptionIfZeroOrLess(double fuelConsumption)
        {
            //Act and Assert
            Assert.That(() => new Car(CAR_MAKE, CAR_MODEL, fuelConsumption, CAR_FUEL_CAPACITY),
                Throws.ArgumentException
                .With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        public void PropertyFuelCapacityShouldThrowExceptionIfZeroOrLess(double fuelCapacity)
        {
            //Act and Assert
            Assert.That(() => new Car(CAR_MAKE, CAR_MODEL, CAR_FUEL_CONSUMPTION, fuelCapacity),
                Throws.ArgumentException
                .With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void ConstructorShouldBeAbleToGetAndSetAllValuesToItsProperties()
        {
            //Assert
            Assert.That(this.audiCar.FuelAmount, Is.EqualTo(0));
            Assert.That(this.audiCar.Make, Is.EqualTo(CAR_MAKE));
            Assert.That(this.audiCar.Model, Is.EqualTo(CAR_MODEL));
            Assert.That(this.audiCar.FuelConsumption, Is.EqualTo(CAR_FUEL_CONSUMPTION));
            Assert.That(this.audiCar.FuelCapacity, Is.EqualTo(CAR_FUEL_CAPACITY));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-50)]
        public void RefuelMethodShouldThrowExeptionIfGivenValueZeroOrNegative(double fuelToRefuel)
        {
            //Act and Assert
            Assert.That(() => this.audiCar.Refuel(fuelToRefuel),
                Throws.ArgumentException
                .With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void FuelAmountShouldBeAlwaysEqualToFuelCapacity()
        {
            //Act
            this.audiCar.Refuel(CAR_FUEL_TO_REFUEL);

            //Assert
            Assert.That(this.audiCar.FuelAmount, Is.EqualTo(this.audiCar.FuelCapacity));
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfNotEnoughFuel()
        {
            //Arrange
            this.audiCar.Refuel(CAR_FUEL_TO_REFUEL);

            //Act and Assert
            Assert.That(() => this.audiCar.Drive(2001),
                Throws.InvalidOperationException
                .With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveMethodShouldDecreaseTheFuelAmount()
        {
            //Arrange
            this.audiCar.Refuel(CAR_FUEL_TO_REFUEL);

            //Act
            this.audiCar.Drive(2000);

            //Assert
            Assert.AreEqual(0, this.audiCar.FuelAmount);
        }
    }
}