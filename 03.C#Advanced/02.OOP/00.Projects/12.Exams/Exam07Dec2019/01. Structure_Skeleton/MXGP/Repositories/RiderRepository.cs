namespace MXGP.Repositories
{
    using System.Linq;

    using Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
            => base.Models
            .FirstOrDefault(r => r.Name == name);
    }
}
