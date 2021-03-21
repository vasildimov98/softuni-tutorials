namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Models.Players.Contracts;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)this.models;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.models.Add(model);
        }
        public bool Remove(IPlayer model)
             => this.models.Remove(model);
        public IPlayer FindByName(string name)
            => this.Models
            .FirstOrDefault(m => m.Username == name);
    }
}
