namespace PlayersAndMonsters.Core.Factories
{
    using System;

    using Common;
    using Contracts;
    using Repositories;
    using Models.Players;
    using Models.Players.Contracts;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var cardRepository = new CardRepository();

            IPlayer player;
            if (type == nameof(Beginner))
            {
                player = new Beginner(cardRepository, username);
            }
            else if (type == nameof(Advanced))
            {
                player = new Advanced(cardRepository, username);
            }
            else
            {
                var msg = string.Format(ExceptionMessages.InvalidType, nameof(Player));
                throw new ArgumentException(msg);
            }

            return player;
        }
    }
}
