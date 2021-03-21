namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private const double PAID_SUBTOTAL_VALUE = 0;

        private readonly Dictionary<string, Invoice> invoiceBySerialNum;

        public Agency()
        {
            this.invoiceBySerialNum = new Dictionary<string, Invoice>();
        }

        public void Create(Invoice invoice)
        {
            var serialNum = invoice.SerialNumber;
            this.CheckIfSerialNumExists(serialNum);

            this.invoiceBySerialNum[serialNum] = invoice;
        }


        public bool Contains(string number)
            => this.invoiceBySerialNum.ContainsKey(number);

        public int Count()
            => this.invoiceBySerialNum.Count;

        public void PayInvoice(DateTime due)
        {
            var invoiceInDueDate = this
                .invoiceBySerialNum
                .Values
                .Where(i => i.DueDate == due);

            this.CheckIfEmpty(invoiceInDueDate);

            foreach (var invoice in invoiceInDueDate)
                invoice.Subtotal = PAID_SUBTOTAL_VALUE;
        }

        public void ThrowInvoice(string number)
        {
            this.ValidateKey(this.invoiceBySerialNum, number);

            this.invoiceBySerialNum.Remove(number);
        }

        public void ThrowPayed()
            => this.invoiceBySerialNum
            .Values
            .Where(i => i.Subtotal == PAID_SUBTOTAL_VALUE)
            .ToList()
            .ForEach(i => this.ThrowInvoice(i.SerialNumber));

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
            => this.invoiceBySerialNum
            .Values
            .Where(i => start <= i.IssueDate && i.IssueDate <= end)
            .OrderBy(i => i.IssueDate);

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var serialNumContainingGivenNumber = this.invoiceBySerialNum
                .Keys
                .Where(s => s.Contains(serialNumber));

            if (serialNumContainingGivenNumber.Count() == 0)
                throw new ArgumentException();

            return serialNumContainingGivenNumber
                .Select(s => this.invoiceBySerialNum[s])
                .OrderByDescending(i => i.SerialNumber);
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            var invoiceInPeriod = this.invoiceBySerialNum
                .Values
                .Where(i => start < i.DueDate && i.DueDate < end);

            this.CheckIfEmpty(invoiceInPeriod);

            foreach (var invoice in invoiceInPeriod)
            {
                this.ThrowInvoice(invoice.SerialNumber);
            }

            return Enumerable.Empty<Invoice>();
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
            => this.invoiceBySerialNum
            .Values
            .Where(i => i.Department == department)
            .OrderByDescending(i => i.Subtotal)
            .ThenBy(i => i.IssueDate);

        public IEnumerable<Invoice> GetAllByCompany(string company)
            => this.invoiceBySerialNum
            .Values
            .Where(i => i.CompanyName == company)
            .OrderByDescending(i => i.SerialNumber);

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var invoicesInDueDate = this.invoiceBySerialNum
                .Values
                .Where(i => i.DueDate == dueDate);

            this.CheckIfEmpty(invoicesInDueDate);

            foreach (var invoice in invoicesInDueDate)
            {
                var newDueDate = invoice.DueDate.AddDays(days);
                invoice.DueDate = newDueDate;
            }
        }

        private void CheckIfSerialNumExists(string serialNum)
        {
            if (this.Contains(serialNum))
                throw new ArgumentException();
        }

        private void CheckIfEmpty(IEnumerable<Invoice> invoiceInDueDate)
        {
            if (invoiceInDueDate.Count() == 0)
                throw new ArgumentException();
        }


        private void ValidateKey<TKey, TValue>(IDictionary<TKey, TValue> dict, TKey key)
        {
            if (!dict.ContainsKey(key))
                throw new ArgumentException();
        }
    }
}
