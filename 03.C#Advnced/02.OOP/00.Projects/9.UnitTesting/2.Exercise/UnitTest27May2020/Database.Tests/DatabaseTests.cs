using Database;

namespace Tests
{
    using Database;// Don't forget to comment on that
    using NUnit.Framework;

    public class DatabaseTests
    {
        //Arrange
        private const int MAX_CAPACITY = 16;
        private const int ADD_ELEMENT = 10;

        private int[] arr;
        private Database database;
        private Database fullDatabase;
        [SetUp]
        public void Setup()
        {
            //Arrange
            this.arr = new int[]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            this.database = new Database();
            this.fullDatabase = new Database(this.arr);
        }

        [Test]
        public void ConstructorShouldSetLenthToArray()
        {
            //Act
            var capacity = this.fullDatabase.Count;
            //Assert
            Assert.That(capacity, Is.EqualTo(MAX_CAPACITY), 
                "Database was not equal to 16!");
        }

        [Test]
        public void DatabaseAddMethodShouldIncreaseCountIfElementAddSuccessfully()
        {
            //Act
            this.database.Add(ADD_ELEMENT);
            //Assert
            Assert.That(this.database.Count, Is.EqualTo(1),
                "Count has not Increase");
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExeptionWhenFull()
        {
            //Act and Assert
            Assert.That(() => this.fullDatabase.Add(ADD_ELEMENT),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"), 
                "Database was not full!");
        }

        [Test]
        public void DatabaseRemoveMethodShouldDecreaseTheCountIfElementRemovedSuccessfully()
        {
            //Act
            this.fullDatabase.Remove();

            //Assert
            Assert.That(this.fullDatabase.Count, Is.EqualTo(MAX_CAPACITY - 1));
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExeptionWhenTheirsNoElements()
        {
            //Act and Assert
            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void DatabaseFetchMethodShouldReturnElementsAsArray()
        {
            //Act
            var copyArray = this.fullDatabase.Fetch();

            //Assert
            CollectionAssert.AreEqual(this.arr, copyArray);
        }
    }
}