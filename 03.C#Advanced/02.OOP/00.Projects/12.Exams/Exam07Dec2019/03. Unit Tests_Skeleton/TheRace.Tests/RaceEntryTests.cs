using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const string RiderName = "Test";

        private const string MotorcycleModel = "Test";
        private const int HorsePower = 150;
        private const double CubicCentimeters = 100;

        private const string ExistingRider = "Rider {0} is already added.";
        private const string RiderInvalid = "Rider cannot be null.";
        private const string RiderAdded = "Rider {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private RaceEntry raceEntry;
        private UnitRider rider;
        private UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.motorcycle = new UnitMotorcycle(MotorcycleModel, HorsePower, CubicCentimeters);
            this.rider = new UnitRider(RiderName, motorcycle);
        }

        [Test]
        public void UnitRiderTestShoudlThrowExceptionIfNameIsNull()
        {
            //Assert
            Assert.That(() => new UnitRider(null, motorcycle),
                Throws.ArgumentNullException);
        }

        [Test]
        public void UnitMotorcycleConstructorShouldSetCorrectValues()
        {
            //Assert
            Assert.That(this.motorcycle, Is.Not.Null);
            Assert.That(this.motorcycle.Model, Is.EqualTo(MotorcycleModel));
            Assert.That(this.motorcycle.HorsePower, Is.EqualTo(HorsePower));
            Assert.That(this.motorcycle.CubicCentimeters, Is.EqualTo(CubicCentimeters));
        }

        [Test]
        public void UnitRiderConstructorShouldSetCorrectValues()
        {
            //Assert
            Assert.That(this.rider, Is.Not.Null);
            Assert.That(this.rider.Name, Is.EqualTo(RiderName));
            Assert.That(this.rider.Motorcycle, Is.Not.Null);
            Assert.That(this.rider.Motorcycle, Is.EqualTo(this.motorcycle));
        }

        [Test]
        public void AddRiderShouldThrowExceptionIfRiderIsNull()
        {
            //Assert
            Assert.That(() => this.raceEntry.AddRider(null),
                Throws.InvalidOperationException
                .With.Message.EqualTo(RiderInvalid));
        }

        [Test]
        public void AddRiderShouldThrowExceptionIfRiderExists()
        {
            //Arrange
            var countOfRiderToAdd = 5;
            this.GetRaceEntryFilledWithRiders(countOfRiderToAdd);
            var nameThatExists = "Test1";

            //Assert
            Assert.That(() => this.raceEntry.AddRider(new UnitRider(nameThatExists, this.motorcycle)),
                Throws.InvalidOperationException
                .With.Message.EqualTo(string.Format(ExistingRider, nameThatExists)));
        }

        [Test]
        public void AddRiderShouldReturnStringIfRiderAddSuccessfully()
        {
            //Arrange
            var expectedCount = 1;
            var expectedString = string.Format(RiderAdded, RiderName);

            //Act
            var actual = this.raceEntry.AddRider(rider);

            //Assert
            Assert.That(this.raceEntry.Counter, Is.EqualTo(expectedCount));
            Assert.That(actual, Is.EqualTo(expectedString));
        }

        [Test]
        public void CalculateAverageHorsepowerShouldThrowExceptionIfRidersLessThanThree()
        {
            //Arrange
            var countOfRiderToAdd = 1;
            this.GetRaceEntryFilledWithRiders(countOfRiderToAdd);

            //Assert
            Assert.That(() => this.raceEntry.CalculateAverageHorsePower(),
                Throws.InvalidOperationException
                .With.Message.EqualTo(string.Format(RaceInvalid, MinParticipants)));
        }

        [Test]
        public void CalculateAverageHorsepowerShouldReturnRightAverageCalculation()
        {
            //Arrange
            var countOfRiderToAdd = 5;
            this.GetRaceEntryFilledWithRiders(countOfRiderToAdd);
            var expectedResult = HorsePower * countOfRiderToAdd / countOfRiderToAdd;

            //Act
            var actual = this.raceEntry.CalculateAverageHorsePower();

            //Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        private void GetRaceEntryFilledWithRiders(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.raceEntry.AddRider(new UnitRider($"{RiderName}{i + 1}", this.motorcycle));
            }
        }
    }
}