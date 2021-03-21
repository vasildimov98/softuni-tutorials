namespace P05_GreedyTimes
{
    using System;
    public class Cash : IComparable<Cash>
    {
        public Cash(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
        public string Name { get;}

        public long Amount { get; set; }

        public int CompareTo(Cash other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
