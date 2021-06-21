using System;

namespace P05_GreedyTimes
{
    public class Gem : IComparable<Gem>
    {
        public Gem(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public string Name { get;}

        public long Amount { get; set; }

        public int CompareTo(Gem other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
