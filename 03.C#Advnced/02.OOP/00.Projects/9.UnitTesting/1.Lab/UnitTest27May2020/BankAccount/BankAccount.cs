namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            this.Amount = amount;
        }
        public decimal Amount { get; private set; }

        public void Deposit(decimal moneyToBeAdd)
        {
            this.Amount += moneyToBeAdd;
        }
    }
}
