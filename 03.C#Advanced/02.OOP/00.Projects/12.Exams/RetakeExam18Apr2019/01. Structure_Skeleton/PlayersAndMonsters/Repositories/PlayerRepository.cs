namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;
        public IReadOnlyCollection<IPlayer> Players
            => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer player)
        {
            this.CheckForNullValue(player);

            if (this.Players.Any(p => p.Username == player.Username))
            {
                var msg = string.Format(ExceptionMessages.InvalidEqualPlayer, player.Username);
                throw new ArgumentException(msg);
            }

            this.players.Add(player);
        }
        public bool Remove(IPlayer player)
        {
            this.CheckForNullValue(player);

            return this.players.Remove(player);
        }
        public IPlayer Find(string username)
            => this.players
            .FirstOrDefault(p => p.Username == username);
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var player in this.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
        private void CheckForNullValue(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNullPlayer);
            }
        }
    }
}
