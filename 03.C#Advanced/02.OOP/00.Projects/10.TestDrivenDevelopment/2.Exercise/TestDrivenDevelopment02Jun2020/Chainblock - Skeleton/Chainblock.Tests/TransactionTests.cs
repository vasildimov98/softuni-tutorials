namespace Chainblock.Tests
{
    using Chainblock.Common;
    using Chainblock.Contracts;
    using Chainblock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        //Arrange
        private const int FIRST_TEST_ID = 1000;
        private const TransactionStatus FIRST_TEST_STATUS = TransactionStatus.Successfull;
        private const string FIRST_TEST_FROM = "Sender";
        private const string FIRST_TEST_TO = "Receiver";
        private const double FIRST_TEST_AMOUNT = 1000;

        private ITransaction transaction;

        [SetUp]
        public void SetUpConstructor()
        {
            transaction = new Transaction(FIRST_TEST_ID, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT);
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void IdPropertyShouldThrowExceptionIfValueIsZeroOrNegative(int id)
        {
            //Act & Assert
            Assert.That(() => new Transaction(id, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_ID_VALUE));
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("               ")]
        public void FromPropertyShouldThrowExceptionIfInvalid(string from)
        {
            //Act & Assert
            Assert.That(() => new Transaction(FIRST_TEST_ID, FIRST_TEST_STATUS, from, FIRST_TEST_TO, FIRST_TEST_AMOUNT),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_FROM_VALUE));
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("               ")]
        public void ToPropertyShouldThrowExceptionIfInvalid(string to)
        {
            //Act & Assert
            Assert.That(() => new Transaction(FIRST_TEST_ID, FIRST_TEST_STATUS, FIRST_TEST_FROM, to, FIRST_TEST_AMOUNT),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_TO_VALUE));
        }
        [TestCase(-1000)]
        [TestCase(0)]
        public void AmountPropertyShouldThrowExceptionIfValueIsZeroOrNegative(int amount)
        {
            //Act & Assert
            Assert.That(() => new Transaction(FIRST_TEST_ID, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, amount),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_AMOUNT_VALUE));
        }
        [Test]
        public void ContructorShouldGetAndSetValuesSuccessfully()
        {
            //Assert
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction.Id, Is.EqualTo(FIRST_TEST_ID));
            Assert.That(transaction.Status, Is.EqualTo(FIRST_TEST_STATUS));
            Assert.That(transaction.From, Is.EqualTo(FIRST_TEST_FROM));
            Assert.That(transaction.To, Is.EqualTo(FIRST_TEST_TO));
            Assert.That(transaction.Amount, Is.EqualTo(FIRST_TEST_AMOUNT));
        }
    }
}
