namespace _02.VaniPlanning
{
    using System;

    public class Invoice : IComparable<Invoice>
    {
        public Invoice(string number, string company, double subtotal, Department dep, DateTime issueDate, DateTime dueDate)
        {
            this.SerialNumber = number;
            this.CompanyName = company;
            this.Subtotal = subtotal;
            this.Department = dep;
            this.IssueDate = issueDate;
            this.DueDate = dueDate;
        }
        public string SerialNumber { get; set; }

        public string CompanyName { get; set; }

        public double Subtotal { get; set; }

        public Department Department { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public override bool Equals(object obj)
        {
            var otherInvoice = obj as Invoice;
            return this.SerialNumber == otherInvoice.SerialNumber;
        }

        public int CompareTo(Invoice otherInvoice)
            => otherInvoice.SerialNumber.CompareTo(this.SerialNumber);

        public override int GetHashCode()
            => this.SerialNumber.GetHashCode();
    }
}
