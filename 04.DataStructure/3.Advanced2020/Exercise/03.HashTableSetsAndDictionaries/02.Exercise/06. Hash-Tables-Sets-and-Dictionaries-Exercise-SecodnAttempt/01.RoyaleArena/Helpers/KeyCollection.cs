namespace _01.RoyaleArena.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Interfaces;

    public abstract class KeyCollection<T> : IComparer<ICard>, IEnumerable<T>
        where T : IComparable<T>
    {
        public KeyCollection() { }

        public abstract SortedSet<T> Keys { get; }
        public T MaxKey => this.Keys.Max;
        public T MinKey => this.Keys.Min;

        public virtual int Compare(ICard firstCard, ICard secondCard)
            => this.GetCardKey(firstCard).CompareTo(this.GetCardKey(secondCard));

        public abstract T GetCardKey(ICard card);

        public void AddKey(T cardKey)
            => this.Keys.Add(cardKey);

        internal void RemoveKey(T cardKey)
            => this.Keys.Remove(cardKey);

        public IEnumerable<T> GetKeysBetweenRange(T lowerKeyRange, T upperKeyRange)
            => this.Keys
            .GetViewBetween(lowerKeyRange, upperKeyRange);

        public IEnumerator<T> GetEnumerator()
            => this.Keys
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
