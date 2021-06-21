using ExtendedDatabase;

namespace Tests
{
    using ExtendedDatabase;
    using System;
    using NUnit.Framework;
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase databaseWithOnePerson;
        private ExtendedDatabase databaseEmpty;
        private ExtendedDatabase fullDatabase;
        private Person person;
        [SetUp]
        public void Setup()
        {
            //Arrange
            var peopleArr = new Person[16];
            var id = 111111111;
            for (int i = 0; i < peopleArr.Length; i++)
            {
                peopleArr[i] = new Person(id, $"Ivan{i + 1}");
                id++;
            }

            this.fullDatabase = new ExtendedDatabase(peopleArr);

            this.person = new Person(111111111, "Ivan1");
            this.databaseWithOnePerson = new ExtendedDatabase(person);
            this.databaseEmpty = new ExtendedDatabase();
        }

        [Test]
        public void ConstructorShouldSetPersonArrAndAddElementsIfGiven()
        {
            //Act
            var count = this.databaseWithOnePerson.Count;

            //Assert
            Assert.That(count, Is.EqualTo(1));
        }
        [Test]
        public void ConstructorCannotCreateDatabaseWithPeopleMoreThanMaxCapacity()
        {
            //Arrange
            var peopleArr = new Person[17];
            var id = 111111111;
            for (int i = 0; i < peopleArr.Length; i++)
            {
                peopleArr[i] = new Person(id, $"Ivan{i + 1}");
                id++;
            }

            //Act and Assert
            Assert.That(() => new ExtendedDatabase(peopleArr),
                Throws.ArgumentException
                .With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExeptionIfFull()
        {
            //Arrange
            var person = new Person(9999999, "Pesho");

            //Act and Assert
            Assert.That(() => this.fullDatabase.Add(person),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfNameExists()
        {
            //Act and Assert
            Assert.That(() => this.databaseWithOnePerson.Add(this.person),
                Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionIfIdExists()
        {
            //Act and Assert
            Assert.That(() => this.databaseWithOnePerson.Add(new Person(111111111, "TestPersonDiff")),
                Throws.InvalidOperationException
                .With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void DatabaseAddMethodShouldIncreaseTheCountWhenAddSuccessfully()
        {
            //Act
            this.databaseWithOnePerson.Add(new Person(12, "Somebody"));
            //Assert
            Assert.That(this.databaseWithOnePerson.Count, Is.EqualTo(2));
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionIfEmpty()
        {
            //Act and Assert
            Assert.That(() => this.databaseEmpty.Remove(),
                Throws.InvalidOperationException);
        }
        [Test]
        public void DatabaseRemoveMethodShouldDecreaseCountIfRemovedSuccesfully()
        {
            //Act
            this.databaseWithOnePerson.Remove();

            //Assert
            Assert.That(this.databaseWithOnePerson.Count, Is.EqualTo(0));
        }
        [Test]
        public void DatabaseFindByUsernameShouldThrowExceptionIfStringIsNull()
        {
            //Arrange
            string name = null;
            //Assert
            Assert.That(() => this.fullDatabase.FindByUsername(name),
                Throws.ArgumentNullException);
        }

        [Test]
        public void DatabaseFindByUsernameShouldThrowExceptionIfNameDoesntExits()
        {
            //Assert
            Assert.That(() => this.fullDatabase.FindByUsername("Nonexistence"),
                Throws.InvalidOperationException
                .With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void DatabaseFindByUsernameShouldReturnPersonWithGivenName()
        {
            //Arrange
            var expectedName = this.person.UserName;

            //Act
            var person = this.databaseWithOnePerson.FindByUsername(expectedName);

            //Assert
            Assert.That(person.UserName, Is.EqualTo(expectedName));
        }

        [Test]
        public void DatabaseFindByIdShouldThrowExceptionIfIdIsNegative()
        {
            //Assert 
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.databaseWithOnePerson.FindById(-12);
            }).Message.Equals("Id should be a positive number!");
        }

        [Test]
        public void DatabaseFindByIdShouldThrowExceptionIfIdNonExistance()
        {
            //Assert 
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.databaseWithOnePerson.FindById(12);
            }).Message.Equals("No user is present by this ID!");
        }
        [Test]
        public void DatabaseFindByIdShouldReturnPersonWithSameId()
        {
            //Arrange
            var id = this.person.Id;
            //Act
            var person = this.databaseWithOnePerson.FindById(id);
            //Assert
            Assert.That(person.Id, Is.EqualTo(id));
        }
    }
}