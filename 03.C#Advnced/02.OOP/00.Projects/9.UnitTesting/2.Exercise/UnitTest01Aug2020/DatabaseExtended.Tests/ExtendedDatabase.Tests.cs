namespace Tests
{
    using System;
    using NUnit.Framework;

    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        //Arrange
        private const int MAX_CAPACITY = 16;
        private const int EXPECTED_ID = 1;
        private const string EXPECTED_NAME = "TestName1";

        private ExtendedDatabase database;
        private ExtendedDatabase emptyDatabase;

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase(this.GetPersonArray(MAX_CAPACITY));
            this.emptyDatabase = new ExtendedDatabase();
        }

        [Test]
        public void ConstructorShouldBeAlbleToSetTheRightAmountOfNumber()
        {
            //Act
            var database = new ExtendedDatabase(this.GetPersonArray(MAX_CAPACITY));

            //Assert
            Assert.That(database.Count, Is.EqualTo(MAX_CAPACITY));
        }

         [Test]
        public void AddRangeShouldThrowExceptionIfDataLengthIsBiggerThanCapacity()
        {
            //Arrange
            var msg = "Provided data length should be in range [0..16]!";

            //Act and Assert
            Assert.That(() => new ExtendedDatabase(this.GetPersonArray(MAX_CAPACITY + 1)),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCapacityIsReached()
        {
            //Arrange
            var msg = "Array's capacity must be exactly 16 integers!";
            var id = 17;
            var person = new Person(id, $"Test{id}");

            //Act and Assert
            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfNameOfPersonAlreadyExits()
        {
            //Arrange
            var msg = "There is already user with this username!";
            var id = 1;
            var person = new Person(id, $"TestName{id}");

            //Act
            this.emptyDatabase.Add(person);

            //Assert
            Assert.That(() => this.emptyDatabase.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfIdAlreadyExits()
        {
            //Arrange
            var msg = "There is already user with this Id!";
            var id = 1;
            var newId = 2;
            var person = new Person(id, $"TestName{id}");
            var newPerson = new Person(id, $"TestName{newId}");

            //Act
            this.emptyDatabase.Add(person);

            //Assert
            Assert.That(() => this.emptyDatabase.Add(newPerson),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldAddMethodSuccessfully()
        {
            //Arrange
            var expectedCount = 1;

            //Act
            this.emptyDatabase.Add(new Person(expectedCount, $"TestName{expectedCount}"));

            //Assert
            Assert.That(this.emptyDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIsEqualToZero()
        {
            //Act and Assert
            Assert.That(() => this.emptyDatabase.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveMethodShouldRemoveSuccessfullyAndDecreaseCount()
        {
            //Arrange
            var expectedCount = 15;

            //Act
            this.database.Remove();

            //Assert
            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNameIsNull()
        {
            //Act and Assert
            Assert.That(() => this.database.FindByUsername(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNameIsNotPresent()
        {
            //Arrange
            var nonexistenceName = "Nonexistence";
            var msg = "No user is present by this username!";

            //Act and Assert
            Assert.That(() => this.database.FindByUsername(nonexistenceName),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FindByUsernameShouldReturnTheSamePerson()
        {
            //Act
            var person = this.database.FindByUsername(EXPECTED_NAME);

            //Assert
            Assert.That(person.Id, Is.EqualTo(EXPECTED_ID));
            Assert.That(person.UserName, Is.EqualTo(EXPECTED_NAME));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsNegative()
        {
            //Arrange
            var negativeID = -EXPECTED_ID;

            //Act and Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(negativeID));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdNotFound()
        {
            //Arrange
            var noId = 17;
            var msg = "No user is present by this ID!";

            //Act and Assert
            Assert.That(() => this.database.FindById(noId),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void FindByIdShouldReturnTheSamePerson()
        {
            //Act
            var person = this.database.FindById(EXPECTED_ID);

            //Assert
            Assert.That(person.Id, Is.EqualTo(EXPECTED_ID));
            Assert.That(person.UserName, Is.EqualTo(EXPECTED_NAME));
        }

        private Person[] GetPersonArray(int capacity)
        {
            var arr = new Person[capacity];

            for (int i = 1; i <= capacity; i++)
            {
                arr[i - 1] = new Person(i, $"TestName{i}");
            }

            return arr;
        }
    }
}