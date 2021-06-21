namespace Chainblock.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using Chainblock.Contracts;
    using Chainblock.Models;
    using Chainblock.Common;

    [TestFixture]
    public class ChainblockTests
    {
        //Arrange
        private const int FIRST_TEST_ID = 100;
        private const TransactionStatus FIRST_TEST_STATUS = TransactionStatus.Successfull;
        private const string FIRST_TEST_FROM = "First Test Sender";
        private const string FIRST_TEST_TO = "First Test Receiver";
        private const double FIRST_TEST_AMOUNT = 1000;

        private IChainblock chainblock;
        private ITransaction firstTestTransaction;

        [SetUp]
        public void SetUpConstructor()
        {
            this.chainblock = new Chainblock();
            this.firstTestTransaction
                = new Transaction(FIRST_TEST_ID, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT);
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfTransactionIsNull()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.Add(null),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_TRANSACTION_VALUE));
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfTransactionAlreadyExists()
        {
            //Act
            this.chainblock.Add(this.firstTestTransaction);

            //Assert
            Assert.That(() => this.chainblock.Add(this.firstTestTransaction),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_ADD_TRANSACTION_OPERATION));
        }
        [Test]
        public void AddMethodShouldAddTransactionToChainblock()
        {
            //Act
            this.chainblock.Add(firstTestTransaction);

            //Assert
            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(this.firstTestTransaction), Is.True);
            Assert.That(this.chainblock.Contains(FIRST_TEST_ID), Is.True);
        }
        [Test]
        public void ContainsTransactionShouldReturnFalseIfTransactionIsNotInTheRecords()
        {
            //Assert
            Assert.That(this.chainblock.Contains(this.firstTestTransaction), Is.False);
        }
        [Test]
        public void ContainsTransactionShouldReturnTrueIfTransactionIsInTheRecords()
        {
            //Arrange
            this.chainblock.Add(this.firstTestTransaction);

            //Assert
            Assert.That(this.chainblock.Contains(this.firstTestTransaction), Is.True);
        }
        [TestCase(-1213)]
        [TestCase(0)]
        public void ContainsIdShouldReturnFalseIfTransactionIsNotInTheRecords(int id)
        {
            //Assert
            Assert.That(this.chainblock.Contains(id), Is.False);
        }
        [Test]
        public void ContainsIdShouldReturnTrueIfTransactionIsInTheRecords()
        {
            //Arrange
            this.chainblock.Add(this.firstTestTransaction);

            //Assert
            Assert.That(this.chainblock.Contains(FIRST_TEST_ID), Is.True);
        }
        [Test]
        public void CountPropertyShouldReturnTheCurrentCountOfTheChainblock()
        {
            //Assert
            Assert.That(this.chainblock.Count, Is.EqualTo(0));

            //Act
            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(new Transaction(101, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT));
            this.chainblock.Add(new Transaction(102, FIRST_TEST_STATUS, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT));

            //Assert
            Assert.That(this.chainblock.Count, Is.EqualTo(3));
        }
        [Test]
        public void ChangeTransactionStatusMethodShouldThrowExceptionIfIdIsInvalid()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.ChangeTransactionStatus(FIRST_TEST_ID, FIRST_TEST_STATUS),
                Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.INVALID_ID_NOT_PRESENT));
        }
        [Test]
        public void ChangeTransactionStatusMethodShouldChangeStatusOfGivenTransaction()
        {
            //Arrange
            this.chainblock.Add(firstTestTransaction);

            //Act
            this.chainblock.ChangeTransactionStatus(FIRST_TEST_ID, TransactionStatus.Aborted);

            //Assert
            Assert.That(firstTestTransaction.Status, Is.EqualTo(TransactionStatus.Aborted));
        }
        [Test]
        public void GetByIdShouldThrowExceptionIfSuchTransactionDoesNotExits()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetById(FIRST_TEST_ID),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_ID_NOT_PRESENT));
        }
        [Test]
        public void RemoveTransactionById()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.RemoveTransactionById(FIRST_TEST_ID),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_ID_NOT_PRESENT));
        }
        [Test]
        public void RemoveMethodShouldRemoveById()
        {
            //Arrange 
            this.chainblock.Add(this.firstTestTransaction);

            //Act
            this.chainblock.RemoveTransactionById(FIRST_TEST_ID);

            //Arrange
            Assert.That(this.chainblock.Count, Is.EqualTo(0));
            Assert.That(this.chainblock.Contains(FIRST_TEST_ID), Is.False);
            Assert.That(this.chainblock.Contains(this.firstTestTransaction), Is.False);
        }
        [Test]
        public void GetByIdShouldReturTransactionById()
        {
            //Arrange
            this.chainblock.Add(firstTestTransaction);

            //Act
            var returnedTransaction = this.chainblock.GetById(FIRST_TEST_ID);

            //Assert
            Assert.That(returnedTransaction, Is.Not.Null);
            Assert.That(returnedTransaction.Id, Is.EqualTo(FIRST_TEST_ID));
            Assert.That(returnedTransaction.Status, Is.EqualTo(FIRST_TEST_STATUS));
            Assert.That(returnedTransaction.From, Is.EqualTo(FIRST_TEST_FROM));
            Assert.That(returnedTransaction.To, Is.EqualTo(FIRST_TEST_TO));
            Assert.That(returnedTransaction.Amount, Is.EqualTo(FIRST_TEST_AMOUNT));
        }
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetByTransactionStatusShouldThrowExceptionIfTheyAreNoSuchTransactions(TransactionStatus ts)
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetByTransactionStatus(ts),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_STATUS_NOT_PRESENT));
        }
        [Test]
        public void GetByTransactionStatusShouldReturnCollectionOrderByamountInDescendingOrder()
        {
            //Arrange
            this.GetChainblockStackedWithTransactions();
            var numberToIncreaseTheOriginalAmount = 4;

            //Act
            var expectedOrderedCollection = this.chainblock
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            //Assert
            Assert.That(expectedOrderedCollection.Count, Is.EqualTo(5));
            Assert.That(expectedOrderedCollection[0].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + numberToIncreaseTheOriginalAmount--));
            Assert.That(expectedOrderedCollection[1].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + numberToIncreaseTheOriginalAmount--));
            Assert.That(expectedOrderedCollection[2].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + numberToIncreaseTheOriginalAmount--));
            Assert.That(expectedOrderedCollection[3].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + numberToIncreaseTheOriginalAmount--));
            Assert.That(expectedOrderedCollection[4].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + numberToIncreaseTheOriginalAmount--));
        }
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllSendersWithTransactionStatusShouldThrowExeptionIfTheirAreNoTransaction(TransactionStatus ts)
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetAllSendersWithTransactionStatus(ts),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_STATUS_NOT_PRESENT));
        }
        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnCollectionOrderAmountOfSenders()
        {
            //Arrange
            this.GetChainblockStackedWithSendersAndReceivers();
            var testSender1 = "Test Sender1";
            var testSender2 = "Test Sender2";
            var testSender3 = "Test Sender3";

            //Act
            var expectedOrderedCollection = this.chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Aborted)
                .ToList();

            //Assert
            Assert.That(expectedOrderedCollection.Count, Is.EqualTo(5));
            Assert.That(expectedOrderedCollection[0], Is.EqualTo(testSender1));
            Assert.That(expectedOrderedCollection[1], Is.EqualTo(testSender1));
            Assert.That(expectedOrderedCollection[2], Is.EqualTo(testSender2));
            Assert.That(expectedOrderedCollection[3], Is.EqualTo(testSender2));
            Assert.That(expectedOrderedCollection[4], Is.EqualTo(testSender3));
        }
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllReceiversWithTransactionStatusShouldThrowExeptionIfTheirAreNoTransaction(TransactionStatus ts)
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetAllReceiversWithTransactionStatus(ts),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_STATUS_NOT_PRESENT));
        }
        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnCollectionOrderAmountOfSenders()
        {
            //Arrange
            this.GetChainblockStackedWithSendersAndReceivers();
            var testReceiver1 = "Test Receiver1";
            var testReceiver2 = "Test Receiver2";
            var testReceiver3 = "Test Receiver3";


            //Act
            var expectedOrderedCollection = this.chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted)
                .ToList();

            //Assert
            Assert.That(expectedOrderedCollection.Count, Is.EqualTo(5));
            Assert.That(expectedOrderedCollection[0], Is.EqualTo(testReceiver1));
            Assert.That(expectedOrderedCollection[1], Is.EqualTo(testReceiver1));
            Assert.That(expectedOrderedCollection[2], Is.EqualTo(testReceiver2));
            Assert.That(expectedOrderedCollection[3], Is.EqualTo(testReceiver2));
            Assert.That(expectedOrderedCollection[4], Is.EqualTo(testReceiver3));
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnEmptyCollectionIfNothingFound()
        {
            //Act
            var expectedCollection = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            //Assert
            CollectionAssert.IsEmpty(expectedCollection);
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCollectionInTheRightOrder()
        {
            //Arrange
            this.GetChainblockStackedWithSendersAndReceivers();

            //Act
            var expectedCollection = this.chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToList();

            //Assert
            Assert.That(expectedCollection[0].Id, Is.EqualTo(FIRST_TEST_ID));
            Assert.That(expectedCollection[1].Id, Is.EqualTo(FIRST_TEST_ID + 1));
            Assert.That(expectedCollection[2].Id, Is.EqualTo(FIRST_TEST_ID + 2));
            Assert.That(expectedCollection[3].Id, Is.EqualTo(FIRST_TEST_ID + 3));
            Assert.That(expectedCollection[4].Id, Is.EqualTo(FIRST_TEST_ID + 4));
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowExceptionIfNothingFound()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetBySenderOrderedByAmountDescending(FIRST_TEST_FROM),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_SENDER_NOT_PRESENT));
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnCollectionInDescendingOrder()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 100000));
            var testSender = "Test Sender1";

            //Act
            var expectedCollection = this.chainblock.GetBySenderOrderedByAmountDescending(testSender)
                .ToList();

            //Assert
            Assert.That(expectedCollection[0].Id, Is.EqualTo(FIRST_TEST_ID + 1));
            Assert.That(expectedCollection[1].Id, Is.EqualTo(FIRST_TEST_ID));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfNothingFound()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetByReceiverOrderedByAmountThenById(FIRST_TEST_TO),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_RECEIVER_NOT_PRESENT));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnCollectionInCorrectOrder()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver1", FIRST_TEST_AMOUNT + 100000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver1", FIRST_TEST_AMOUNT + 100000));
            var testReceiver = "Test Receiver1";

            //Act
            var expectedCollection = this.chainblock.GetByReceiverOrderedByAmountThenById(testReceiver)
                .ToList();

            //Assert
            Assert.That(expectedCollection[0].Id, Is.EqualTo(FIRST_TEST_ID + 1));
            Assert.That(expectedCollection[0].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 100000));

            Assert.That(expectedCollection[1].Id, Is.EqualTo(FIRST_TEST_ID + 2));
            Assert.That(expectedCollection[1].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 100000));

            Assert.That(expectedCollection[2].Id, Is.EqualTo(FIRST_TEST_ID));
            Assert.That(expectedCollection[2].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 2000));
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionIfNothingFound()
        {
            //Act
            var expectedCollection = this.chainblock.GetByTransactionStatusAndMaximumAmount(FIRST_TEST_STATUS, FIRST_TEST_AMOUNT);

            //Assert
            CollectionAssert.IsEmpty(expectedCollection);
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnCollectionInCorrectOrder()
        {
            //Arrange
            this.GetChainblockStackedWithSendersAndReceivers();

            //Act
            var expectedCollection = this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, FIRST_TEST_AMOUNT + 1000)
                .ToList();

            //Assert
            Assert.That(expectedCollection.Count, Is.EqualTo(3));
            Assert.That(expectedCollection[0].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 1000));
            Assert.That(expectedCollection[1].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 100));
            Assert.That(expectedCollection[2].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 0));
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowExceptionIfNothingFound()
        {
            //Act & Assert
            Assert.That(() => this.chainblock.GetBySenderAndMinimumAmountDescending(FIRST_TEST_FROM, FIRST_TEST_AMOUNT),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_SENDER_NOT_PRESENT));
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCollectionInCorrectOrder()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver2", FIRST_TEST_AMOUNT + 1500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver3", FIRST_TEST_AMOUNT + 1000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver4", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver5", FIRST_TEST_AMOUNT + 100));
            var testSender = "Test Sender1";

            //Act
            var expectedCollection = this.chainblock
                .GetBySenderAndMinimumAmountDescending(testSender, FIRST_TEST_AMOUNT + 500)
                .ToList();

            //Assert
            Assert.That(expectedCollection.Count, Is.EqualTo(3));
            Assert.That(expectedCollection[0].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 2000));
            Assert.That(expectedCollection[1].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 1500));
            Assert.That(expectedCollection[2].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 1000));
        }
        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowExceptionIfNothingFound()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver1", FIRST_TEST_AMOUNT + 1500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver1", FIRST_TEST_AMOUNT + 1000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender4", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender5", "Test Receiver1", FIRST_TEST_AMOUNT + 100));
            var testReceiver = "Test Receiver1";

            //Act & Assert
            Assert.That(() => this.chainblock.GetByReceiverAndAmountRange(testReceiver, 10000000, 100000000),
                Throws.InvalidOperationException
                .With.Message.EqualTo(ExceptionMessages.INVALID_RECEIVER_NOT_PRESENT));
        }
        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnCollectionInCorrectOrder()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver1", FIRST_TEST_AMOUNT + 1500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender4", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender5", "Test Receiver1", FIRST_TEST_AMOUNT + 100));
            var testReceiver = "Test Receiver1";

            //Act
            var expectedCollection = this.chainblock
                .GetByReceiverAndAmountRange(testReceiver, FIRST_TEST_AMOUNT + 500, FIRST_TEST_AMOUNT + 2000)
                .ToList();

            //Assert
            Assert.That(expectedCollection.Count, Is.EqualTo(3));
            Assert.That(expectedCollection[0].Id, Is.EqualTo(FIRST_TEST_ID + 1));
            Assert.That(expectedCollection[1].Id, Is.EqualTo(FIRST_TEST_ID + 2));
            Assert.That(expectedCollection[2].Id, Is.EqualTo(FIRST_TEST_ID + 3));
        }
        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionIfNothingFound()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver1", FIRST_TEST_AMOUNT + 1500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender4", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender5", "Test Receiver1", FIRST_TEST_AMOUNT + 100));

            //Act
            var expectedCollection = this.chainblock.GetAllInAmountRange(1, 10);

            //Assert
            CollectionAssert.IsEmpty(expectedCollection);
        }
        [Test]
        public void GetAllInAmountRangeShouldReturnCollectionInTheRightOrder()
        {
            //Arrange
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender4", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver1", FIRST_TEST_AMOUNT + 1500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver1", FIRST_TEST_AMOUNT + 500));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender5", "Test Receiver1", FIRST_TEST_AMOUNT + 100));

            //Act
            var expectedCollection = this.chainblock
                .GetAllInAmountRange(FIRST_TEST_AMOUNT + 500, FIRST_TEST_AMOUNT + 1500)
                .ToList();

            //Assert
            Assert.That(expectedCollection[0].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 500));
            Assert.That(expectedCollection[1].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 1500));
            Assert.That(expectedCollection[2].Amount, Is.EqualTo(FIRST_TEST_AMOUNT + 500));
        }

        private void GetChainblockStackedWithTransactions()
        {
            for (int i = 0; i < 5; i++)
            {
                this.chainblock.Add(new Transaction(100 + i, TransactionStatus.Successfull, FIRST_TEST_FROM, FIRST_TEST_TO, FIRST_TEST_AMOUNT + i));
            }
        }
        private void GetChainblockStackedWithSendersAndReceivers()
        {
            var idChanger = FIRST_TEST_ID;
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender1", "Test Receiver1", FIRST_TEST_AMOUNT + 2000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver2", FIRST_TEST_AMOUNT + 1000));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender2", "Test Receiver2", FIRST_TEST_AMOUNT + 100));
            this.chainblock.Add(new Transaction(idChanger++, TransactionStatus.Aborted, "Test Sender3", "Test Receiver3", FIRST_TEST_AMOUNT + 0));
        }
    }
}
