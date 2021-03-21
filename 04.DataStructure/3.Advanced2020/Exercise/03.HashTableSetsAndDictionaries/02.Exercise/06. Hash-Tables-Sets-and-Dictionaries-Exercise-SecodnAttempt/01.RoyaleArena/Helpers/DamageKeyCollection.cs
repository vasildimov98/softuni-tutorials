namespace _01.RoyaleArena.Helpers
{
    using System.Collections.Generic;

    using Interfaces;

    public class DamageKeyCollection
        : KeyCollection<double>
    {
        private readonly SortedSet<double> keys;

        public DamageKeyCollection()
        {
            this.keys = new SortedSet<double>();
        }

        public override SortedSet<double> Keys => this.keys;

        public override double GetCardKey(ICard card)
            => card.Damage;

        public override int Compare(ICard firstCard, ICard secondCard)
        {
            var cardsCompare = base.Compare(secondCard, firstCard);

            if (cardsCompare == 0)
                cardsCompare = firstCard.Id.CompareTo(secondCard.Id);

            return cardsCompare;
        }
    }
}
