using System;
using System.Collections.Generic;

namespace _02.FitGym
{
    public class Trainer : IComparable<Trainer>
    {
        public Trainer(int id, string name, int popularity)
        {
            this.Id = id;
            this.Name = name;
            this.Popularity = popularity;
            this.Members = new HashSet<Member>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public HashSet<Member> Members { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Trainer;

            return other.Id == this.Id;
        }

        public int CompareTo(Trainer other)
            => this.Members.Count.CompareTo(other.Members.Count) == 0 ?
            this.Popularity.CompareTo(other.Popularity) :
            this.Members.Count.CompareTo(other.Members.Count);

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}