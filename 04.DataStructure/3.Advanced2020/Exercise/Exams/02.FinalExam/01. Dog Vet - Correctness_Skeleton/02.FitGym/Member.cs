namespace _02.FitGym
{
    using System;

    public class Member : IComparable<Member>
    {
        public Member(int id, string name, DateTime registrationDate, int visits)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.Visits = visits;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Visits { get; set; }

        public Trainer Trainer { get; set; }

        public override bool Equals(object obj)
        {
            var member = obj as Member;

            return this.Id == member.Id;
        }

        public int CompareTo(Member other)
            => this.RegistrationDate.CompareTo(other.RegistrationDate) == 0 ?
            other.Name.CompareTo(this.Name) :
            this.RegistrationDate.CompareTo(other.RegistrationDate);

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}