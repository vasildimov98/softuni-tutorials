namespace Demo.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BankTests
    {
        [Test]
        public void BankAccountShouldHaveManager()
        {
            var accountMenager = new AccountManager();

            var bank = new Bank(accountMenager);

            Assert.That(bank.AccountManager, Is.EqualTo(accountMenager));
        }
    }
}
