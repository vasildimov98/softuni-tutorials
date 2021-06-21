namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates; 

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)this.privates;

        public void AddPrivate(IPrivate @private)
            => this.privates.Add(@private);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var @private in this.privates)
            {
                sb.AppendLine($"  {@private}");
            }
                    

            return sb.ToString().TrimEnd();
        }
    }
}
