namespace BankAccountTests
{
    using BankAccount;
    using NUnit.Framework;

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void BankAccountShouldSetAnInitialValue()
        {
            //Arrange and Act
            var bankAccount = new BankAccount(12);

            //Assert 
            Assert.That(bankAccount.Amount, Is.EqualTo(12));
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            //Arrange
            var bankAccount = new BankAccount(0);

            //Act
            bankAccount.Deposit(5000m);

            //Assert
            Assert.That(bankAccount.Amount, Is.EqualTo(5000m));
        }
    }
}