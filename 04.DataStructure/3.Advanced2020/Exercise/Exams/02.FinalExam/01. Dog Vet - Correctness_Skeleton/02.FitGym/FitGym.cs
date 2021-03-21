namespace _02.FitGym
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FitGym : IGym
    {
        private readonly SortedDictionary<int, Member> memberById;
        private readonly SortedDictionary<int, Trainer> trainerById;

        public FitGym()
        {
            this.memberById = new SortedDictionary<int, Member>();
            this.trainerById = new SortedDictionary<int, Trainer>();
        }

        public int MemberCount => this.memberById.Count;

        public int TrainerCount => this.trainerById.Count;

        public void AddMember(Member member)
        {
            if (this.Contains(member))
                throw new ArgumentException();

            this.memberById[member.Id] = member;
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.Contains(trainer))
                throw new ArgumentException();

            this.trainerById[trainer.Id] = trainer;
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.Contains(trainer)
               || member.Trainer != null)
                throw new ArgumentException();

            if (!this.Contains(member))
                this.memberById[member.Id] = member;

            member.Trainer = trainer;
            trainer.Members.Add(member);
        }

        public bool Contains(Member member)
            => this.memberById.ContainsKey(member.Id);

        public bool Contains(Trainer trainer)
            => this.trainerById.ContainsKey(trainer.Id);

        public Trainer FireTrainer(int id)
        {
            if (!this.trainerById.ContainsKey(id))
                throw new ArgumentException();

            var trainer = this.trainerById[id];

            this.trainerById.Remove(id);

            foreach (var member in trainer.Members)
            {
                member.Trainer = null;
            }

            return trainer;
        }

        public Member RemoveMember(int id)
        {
            if (!this.memberById.ContainsKey(id))
                throw new ArgumentException();

            var member = this.memberById[id];
            this.memberById.Remove(member.Id);
            
            if (member.Trainer != null)
            {
                var trainer = member.Trainer;
                trainer.Members.Remove(member);
            }

            return member;
        }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
            => this.memberById
            .Values
            .OrderBy(m => m);

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
            => this.trainerById
            .Values
            .OrderBy(tr => tr.Popularity);

        public IEnumerable<Member>
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
            => this.trainerById[trainer.Id]
            .Members
            .OrderBy(m => m);

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
            => this.trainerById
                .Values
                .Where(tr => lo <= tr.Popularity && tr.Popularity <= hi)
                .SelectMany(tr => tr.Members)
                .OrderBy(m => m.Visits)
                .ThenBy(m => m.Name);


        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
            => this.trainerById
            .Values
            .ToDictionary(k => k, v => v.Members);
    }
}