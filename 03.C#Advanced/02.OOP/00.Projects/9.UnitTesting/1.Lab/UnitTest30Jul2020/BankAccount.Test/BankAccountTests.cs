namespace Demo.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BankAccountTests
    {
        // Arrange
        private const decimal INIT_AMOUNT = 2000m;

        private BankAccount bankAccount;

        [SetUp]
        public void SetUp()
        {
            this.bankAccount = new BankAccount(INIT_AMOUNT);
        }

        [Test]
        public void AmountPropertyShouldThrowExceptionIfValueLessThanZero()
        {
            // Arrange
            var negativeAmount = -2000m;
            var msg = "Amount cannot be less than zero!";

            // Act
            // Assert
            Assert.That(() => new BankAccount(negativeAmount),
                Throws.ArgumentException.With.Message.EqualTo(msg), "It should throw exception!");
        }

        [Test]
        public void ContructorShouldSetTheGivenValue()
        {
            // Assert 
            Assert.That(bankAccount.Amount, Is.EqualTo(2000m),
                "Value is not the same as the one given to the constructor!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void DepositMethodShouldThrowExceptionIfGivenZeroOrLess(decimal deposit)
        {
            // Arrange
            var msg = "Deposit cannot be less or equal to zero!";

            // Act and Assert
            Assert.That(() => bankAccount.Deposit(deposit),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void DepositMethodShouldIncreaseAmountWhenCalled()
        {
            // Arrange
            var deposit = 1000m;
            var expectedResult = INIT_AMOUNT + deposit;

            // Act
            this.bankAccount.Deposit(deposit);

            // Assert
            Assert.That(this.bankAccount.Amount, Is.EqualTo(expectedResult));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void WithdrawMethodShouldThrowExceptionIfValueIsLessOrEqualToZero(decimal widrawal)
        {
            // Arrange
            var msg = "Withdrawal cannot be less or equal to zero!";

            // Act and Assert
            Assert.That(() => bankAccount.Withdraw(widrawal),
                Throws.ArgumentException.With.Message.EqualTo(msg));
        }

        [Test]
        public void WithdrawMethodShouldThrowExceptionIfNotEnoughMoneyInAccount()
        {
            // Arrange
            var withdrawal = INIT_AMOUNT * 2;
            var msg = "Not enough money";

            // Assert and Act
            Assert.That(() => this.bankAccount.Withdraw(withdrawal),
                Throws.InvalidOperationException.With.Message.EqualTo(msg));
        }

        [Test]
        public void WithdrawMethodShouldDecreaseTheAmountIfOperationSucceed()
        {
            // Arrange
            var withdrawal = INIT_AMOUNT - 500;
            var expectedResult = INIT_AMOUNT - withdrawal;

            // Act
            this.bankAccount.Withdraw(withdrawal);

            // Assert
            Assert.That(this.bankAccount.Amount, Is.EqualTo(expectedResult));
        }
    }
}
