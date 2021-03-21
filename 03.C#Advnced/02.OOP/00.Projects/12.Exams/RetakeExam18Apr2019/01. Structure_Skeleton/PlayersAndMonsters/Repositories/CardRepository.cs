namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Models.Cards.Contracts;

    public class CardRepository : ICardRepository
    {
        private readonly ICollection<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;
        public IReadOnlyCollection<ICard> Cards
            => (IReadOnlyCollection<ICard>)this.cards;

        public void Add(ICard card)
        {
            this.CheckForNullValue(card);

            if (this.Cards.Any(c => c.Name == card.Name))
            {
                var msg = string.Format(ExceptionMessages.InvalidEqualCard, card.Name);
                throw new ArgumentException(msg);
            }

            this.cards.Add(card);
        }
        public bool Remove(ICard card)
        {
            this.CheckForNullValue(card);

            return this.cards.Remove(card);
        }
        public ICard Find(string name)
            => this.Cards
            .FirstOrDefault(c => c.Name == name);

        private void CheckForNullValue(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNullCard);
            }
        }
    }
}
