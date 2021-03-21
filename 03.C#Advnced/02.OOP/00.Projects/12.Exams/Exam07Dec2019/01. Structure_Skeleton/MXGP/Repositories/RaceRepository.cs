namespace MXGP.Repositories
{
    using System.Linq;

    using Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
         => base.Models
            .FirstOrDefault(r => r.Name == name);
    }
}
