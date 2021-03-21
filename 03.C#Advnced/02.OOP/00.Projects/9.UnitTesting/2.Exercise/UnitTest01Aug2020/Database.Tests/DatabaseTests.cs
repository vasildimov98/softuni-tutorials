namespace Tests
{
    using NUnit.Framework;
    public class DatabaseTests
    {
        //Arrange

        private const int MAX_CAPACITY = 16;

        private Database.Database database; 
        private Database.Database emptyDatabase;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(this.GetInt32Array(MAX_CAPACITY));
            this.emptyDatabase = new Database.Database();
        }

        [Test]
        public void ConstructorShouldBeAlbleToSetTheRightAmountOfNumber()
        {
            //Act
            var database = new Database.Database(this.GetInt32Array(MAX_CAPACITY));

            //Assert
            Assert.That(database.Count, Is.EqualTo(MAX_CAPACITY));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCapacityIsReached()
        {
            //Arrange
            var msg = "Array's capacity must be exactly 16 integers!";
            var number = 17;

            //Act and Assert
            Assert.That(() => this.database.Add(number),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void AddMethodShouldAddMethodSuccessfully()
        {
            //Arrange
            var expectedCount = 1;

            //Act
            this.emptyDatabase.Add(expectedCount);

            //Assert
            Assert.That(this.emptyDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIsEqualToZero()
        {
            //Arrange
            var msg = "The collection is empty!";

            //Act and Assert
            Assert.That(() => this.emptyDatabase.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
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
        public void FetchMethodShouldReturnACoppyOfTheNumbers()
        {
            //Act
            var arr = this.database.Fetch();

            //Assert
            Assert.That(arr.Length, Is.EqualTo(MAX_CAPACITY));
            Assert.That(arr[15], Is.EqualTo(MAX_CAPACITY));
        }

        private int[] GetInt32Array(int capacity)
        {
            var arr = new int[capacity];

            for (int i = 1; i <= capacity; i++)
            {
                arr[i - 1] = i;
            }

            return arr;
        }
    }
}