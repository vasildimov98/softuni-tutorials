namespace Demo
{
    using System;

    public class BankAccount
    {
        private decimal amount;

        public BankAccount(decimal initialAmount)
        {
            this.Amount = initialAmount;
        }

        public decimal Amount
        {
            get => this.amount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be less than zero!");
                }

                this.amount = value;
            }
        }

        public void Deposit(decimal deposit)
        {
            if (deposit <= 0)
            {
                throw new ArgumentException("Deposit cannot be less or equal to zero!");
            }

            this.Amount += deposit;
        }
        public void Withdraw(decimal withdrawal)
        {
            if (withdrawal <= 0)
            {
                throw new ArgumentException("Withdrawal cannot be less or equal to zero!");
            }

            if (this.Amount - withdrawal < 0)
            {
                throw new InvalidOperationException("Not enough money");
            }

            this.Amount -= withdrawal;
        }
    }
}
