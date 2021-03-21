namespace Chainblock.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Contracts;

    public class Chainblock : IChainblock
    {
        private HashSet<int> transactionsIds;
        private List<ITransaction> transactionByIndex;
        private Dictionary<int, ITransaction> transactionById;
        private Dictionary<string, List<ITransaction>> transactionByStatus;
        private Dictionary<string, List<ITransaction>> transactionsBySenders;
        private Dictionary<string, List<ITransaction>> transactionsByReceiver;
        public Chainblock()
        {
            this.transactionsIds = new HashSet<int>();
            this.transactionByIndex = new List<ITransaction>();
            this.transactionById = new Dictionary<int, ITransaction>();
            this.transactionByStatus = new Dictionary<string, List<ITransaction>>();
            this.transactionsBySenders = new Dictionary<string, List<ITransaction>>();
            this.transactionsByReceiver = new Dictionary<string, List<ITransaction>>();
        }
        public int Count => this.transactionById.Count;
        public void Add(ITransaction tx)
        {
            if (tx == null)
            {
                this.ThrowArgumentException(ExceptionMessages.INVALID_TRANSACTION_VALUE);
            }

            if (this.Contains(tx))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_ADD_TRANSACTION_OPERATION);
            }

            var id = tx.Id;
            var sender = tx.From;
            var receiver = tx.To;
            var transactionStatus = tx.Status.ToString();

            this.transactionsIds.Add(id);
            this.transactionByIndex.Add(tx);
            this.transactionById[id] = tx;

            if (!this.transactionByStatus.ContainsKey(transactionStatus))
            {
                this.transactionByStatus[transactionStatus] = new List<ITransaction>();
            }

            this.transactionByStatus[transactionStatus].Add(tx);

            if (!transactionsBySenders.ContainsKey(sender))
            {
                this.transactionsBySenders[sender] = new List<ITransaction>();
            }

            this.transactionsBySenders[sender].Add(tx);

            if (!transactionsByReceiver.ContainsKey(receiver))
            {
                this.transactionsByReceiver[receiver] = new List<ITransaction>();
            }

            this.transactionsByReceiver[receiver].Add(tx);
        }
        public bool Contains(ITransaction tx)
        {
            return this.transactionsIds.Contains(tx.Id);
        }
        public bool Contains(int id)
        {
            return this.transactionsIds.Contains(id);
        }
        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                ThrowArgumentException(ExceptionMessages.INVALID_ID_NOT_PRESENT);
            }

            var transaction = this.GetById(id);

            transaction.Status = newStatus;
        }
        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_ID_NOT_PRESENT);
            }

            var transaction = this.GetById(id);
            var sender = transaction.From;
            var receiver = transaction.To;
            var statusAsString = transaction.Status.ToString();

            this.transactionsBySenders[sender].Remove(transaction);
            this.transactionsByReceiver[receiver].Remove(transaction);
            this.transactionByStatus[statusAsString].Remove(transaction);
            this.transactionByIndex.Remove(transaction);
            this.transactionsIds.Remove(id);
            this.transactionById.Remove(id);
        }
        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_ID_NOT_PRESENT);
            }

            return this.transactionById[id];
        }
        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var statusAsString = status.ToString();

            if (!transactionByStatus.ContainsKey(statusAsString))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_STATUS_NOT_PRESENT);
            }

            return this.transactionByStatus[statusAsString]
                .OrderByDescending(tr => tr.Amount);
        }
        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var statusAsString = status.ToString();

            if (!this.transactionByStatus.ContainsKey(statusAsString))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_STATUS_NOT_PRESENT);
            }

            return this.transactionByStatus[statusAsString]
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.From);
        }
        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var statusAsString = status.ToString();

            if (!this.transactionByStatus.ContainsKey(statusAsString))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_STATUS_NOT_PRESENT);
            }

            return this.transactionByStatus[statusAsString]
                .OrderByDescending(tr => tr.Amount)
                .Select(tr => tr.To);
        }
        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactionByIndex
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToList();
        }
        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!this.transactionsBySenders.ContainsKey(sender))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_SENDER_NOT_PRESENT);
            }

            return this.transactionsBySenders[sender]
                .OrderByDescending(tr => tr.Amount);
        }
        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!transactionsByReceiver.ContainsKey(receiver))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_RECEIVER_NOT_PRESENT);
            }

            return this.transactionsByReceiver[receiver]
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToList();
        }
        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var statusAsString = status.ToString();
            if (!transactionByStatus.ContainsKey(statusAsString))
            {
                return Enumerable.Empty<ITransaction>();
            }

            return this.transactionByStatus[statusAsString]
                .OrderByDescending(tr => tr.Amount)
                .Where(tr => tr.Amount <= amount)
                .ToList();
        }
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!transactionsBySenders.ContainsKey(sender))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_SENDER_NOT_PRESENT);
            }

            var collection = this.transactionsBySenders[sender]
                .Where(tr => tr.Amount > amount)
                .OrderByDescending(tr => tr.Amount)
                .ToArray();

            if (!collection.Any())
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_SENDER_NOT_PRESENT);
            }

            return collection;
        }
        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!transactionsByReceiver.ContainsKey(receiver))
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_RECEIVER_NOT_PRESENT);
            }

            var collection = this.transactionsByReceiver[receiver]
                .Where(tr => lo <= tr.Amount && tr.Amount < hi)
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id)
                .ToArray();

            if (!collection.Any())
            {
                this.ThrowInvalidOperationException(ExceptionMessages.INVALID_RECEIVER_NOT_PRESENT);
            }

            return collection;
        }
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactionByIndex
                .Where(tr => lo <= tr.Amount && tr.Amount <= hi)
                .ToList();
        }
        public IEnumerator<ITransaction> GetEnumerator() => this.transactionByIndex.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
        private void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}
