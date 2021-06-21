namespace Tests
{
    using NUnit.Framework;

    using CarManager;

    public class CarTests
    {
        //Arrange
        private const string MAKE = "WV";
        private const string MODEL = "Golf";
        private const double FUEL_CONSUMPTION = 10;
        private const double FUEL_CAPACITY = 500;

        private Car car;

        //Act
        [SetUp]
        public void Setup()
        {
            this.car = new Car(MAKE, MODEL, FUEL_CONSUMPTION, FUEL_CAPACITY);
        }

        [Test]
        public void ConstructorShouldSetTheRightValuesToProperties()
        {
            //Assert
            Assert.That(this.car.Make, Is.EqualTo(MAKE));
            Assert.That(this.car.Model, Is.EqualTo(MODEL));
            Assert.That(this.car.FuelConsumption, Is.EqualTo(FUEL_CONSUMPTION));
            Assert.That(this.car.FuelCapacity, Is.EqualTo(FUEL_CAPACITY));
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void MakePropertyShouldThrowExceptionIfValueIsInvalid()
        {
            //Arrange
            var msg = "Make cannot be null or empty!";

            //Assert
            Assert.That(() => new Car(null, MODEL, FUEL_CONSUMPTION, FUEL_CAPACITY),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void ModelPropertyShouldThrowExceptionIfValueIsInvalid()
        {
            //Arrange
            var msg = "Model cannot be null or empty!";

            //Assert
            Assert.That(() => new Car(MAKE, null, FUEL_CONSUMPTION, FUEL_CAPACITY),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FuelConsumptionPropertyShouldThrowExceptionIfValueIsInvalid()
        {
            //Arrange
            var msg = "Fuel consumption cannot be zero or negative!";
            var invalidFuelConsumption = 0;

            //Assert
            Assert.That(() => new Car(MAKE, MODEL, invalidFuelConsumption, FUEL_CAPACITY),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FuelCapacityPropertyShouldThrowExceptionIfValueIsInvalid()
        {
            //Arrange
            var msg = "Fuel capacity cannot be zero or negative!";
            var invalidFuelCapacity = -FUEL_CAPACITY;

            //Assert
            Assert.That(() => new Car(MAKE, MODEL, FUEL_CONSUMPTION, invalidFuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfParameterIsInvalid()
        {
            //Arrange
            var fuelToRefuel = 0;
            var msg = "Fuel amount cannot be zero or negative!";

            //Act and Assert
            Assert.That(() => this.car.Refuel(fuelToRefuel),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void RefuelMethodShouldRefuelOnlyToTheCapacityEvenIsParameterIsBigger()
        {
            //Arrange
            var fuelToRefuel = 5000;

            //Act
            this.car.Refuel(fuelToRefuel);

            //Assert
            Assert.That(this.car.FuelAmount, Is.EqualTo(FUEL_CAPACITY));
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfNotEnoughFuelAmount()
        {
            //Arrange
            var distance = 50;
            var msg = "You don't have enough fuel to drive!";

            //Act and Assert
            Assert.That(() => this.car.Drive(distance),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void DriveMethodShouldDecreaseTheAmount()
        {
            //Arrange
            var fuelToRefuel = 5000;
            var distance = 50d;
            var fuelNeeded = (distance / 100) * FUEL_CONSUMPTION;

            var expectedResult = FUEL_CAPACITY - fuelNeeded;

            //Act
            this.car.Refuel(fuelToRefuel);
            this.car.Drive(distance);

            //Assert
            Assert.That(this.car.FuelAmount, Is.EqualTo(expectedResult));
        }
    }
}