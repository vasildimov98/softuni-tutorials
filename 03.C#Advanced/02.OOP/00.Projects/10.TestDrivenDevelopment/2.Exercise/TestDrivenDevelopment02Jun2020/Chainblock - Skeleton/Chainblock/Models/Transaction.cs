namespace Chainblock.Models
{
    using System;

    using Common;
    using Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0)
                {
                    ThrowArgumentExceptionMessage(ExceptionMessages
                        .INVALID_ID_VALUE);
                }

                this.id = value;
            }
        }
        public TransactionStatus Status
        {
            get => this.status;
            set => this.status = value;
        }
        public string From
        {
            get => this.from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowArgumentExceptionMessage(ExceptionMessages
                        .INVALID_FROM_VALUE);
                }

                this.from = value;
            }
        }
        public string To
        {
            get => this.to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowArgumentExceptionMessage(ExceptionMessages
                        .INVALID_TO_VALUE);
                }

                this.to = value;
            }
        }
        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    ThrowArgumentExceptionMessage(ExceptionMessages
                        .INVALID_AMOUNT_VALUE);
                }

                this.amount = value;
            }
        }

        private void ThrowArgumentExceptionMessage(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
