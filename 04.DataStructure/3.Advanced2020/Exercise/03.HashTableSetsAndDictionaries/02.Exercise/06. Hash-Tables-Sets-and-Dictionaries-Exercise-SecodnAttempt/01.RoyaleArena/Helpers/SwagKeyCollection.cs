namespace _01.RoyaleArena.Helpers
{
    using System.Collections.Generic;

    using Interfaces;

    public class SwagKeyCollection : KeyCollection<double>
    {
        private readonly SortedSet<double> keys;

        public SwagKeyCollection()
        {
            this.keys = new SortedSet<double>();
        }

        public override SortedSet<double> Keys => this.keys;

        public override double GetCardKey(ICard card)
            => card.Swag;

        public override int Compare(ICard firstCard, ICard secondCard)
        {
            var cardCompare = base.Compare(secondCard, firstCard);

            if (cardCompare == 0)
                cardCompare = firstCard.Id.CompareTo(secondCard.Id);

            return cardCompare;
        }
    }
}