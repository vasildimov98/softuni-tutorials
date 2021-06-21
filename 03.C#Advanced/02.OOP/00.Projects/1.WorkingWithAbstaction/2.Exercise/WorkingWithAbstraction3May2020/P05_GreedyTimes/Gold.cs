using System;

namespace P05_GreedyTimes
{
    public class Gold : IComparable<Gold>
    {
        public Gold(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public string Name {get;}

        public long Amount { get; set; }

        public int CompareTo(Gold other)
        {
            return this.Name.ToLower().CompareTo(other.Name.ToLower());
        }
    }
}
