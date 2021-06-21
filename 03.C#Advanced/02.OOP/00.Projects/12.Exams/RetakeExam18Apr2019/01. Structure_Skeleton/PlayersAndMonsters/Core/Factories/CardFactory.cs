namespace PlayersAndMonsters.Core.Factories
{
    using System;

    using Common;
    using Contracts;
    using Models.Cards;
    using Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card;
            if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            else if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else
            {
                var msg = string.Format(ExceptionMessages.InvalidType, nameof(Card));
                throw new ArgumentException(msg);
            }

            return card;
        }
    }
}
