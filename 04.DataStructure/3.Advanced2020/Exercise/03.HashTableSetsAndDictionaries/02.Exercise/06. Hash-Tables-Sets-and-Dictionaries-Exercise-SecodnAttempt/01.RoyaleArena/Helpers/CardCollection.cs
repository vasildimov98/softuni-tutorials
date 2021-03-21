namespace _01.RoyaleArena.Helpers
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Interfaces;

    public class CardCollection
        : IEnumerable<BattleCard>
    {
        private readonly KeyCollection<double> keyCollection;
        private readonly Dictionary<IComparable, LinkedList<BattleCard>> cardsByKey;

        public CardCollection(KeyCollection<double> keyCollection)
        {
            this.keyCollection = keyCollection;

            this.cardsByKey = new Dictionary<IComparable, LinkedList<BattleCard>>();
        }

        public int Count => this.cardsByKey.Count;

        public double MaxKey => this.keyCollection.MaxKey;
        public double MinKey => this.keyCollection.MinKey;

        public void AddCard(BattleCard card)
        {
            var cardKey = this.keyCollection.GetCardKey(card);
            if (!cardsByKey.ContainsKey(cardKey))
                this.cardsByKey[cardKey] = new LinkedList<BattleCard>();
            this.keyCollection.AddKey(cardKey);
            this.cardsByKey[cardKey].AddLast(card);
        }

        public void RemoveCard(BattleCard card)
        {
            var cardKey = this.keyCollection.GetCardKey(card);
            if (!cardsByKey.ContainsKey(cardKey))
                return;

            this.cardsByKey[cardKey].Remove(card);
            if (this.cardsByKey[cardKey].Count == 0)
            {
                this.cardsByKey.Remove(cardKey);
                this.keyCollection.RemoveKey(cardKey);
            }
        }

        public IEnumerable<BattleCard> GetCardsBetweenRange(double lowerKeyRange, double upperKeyRange)
            => this.keyCollection
            .GetKeysBetweenRange(lowerKeyRange, upperKeyRange)
            .SelectMany(key => this.cardsByKey[key]);

        public IEnumerable<BattleCard> FindFirstNCards(int n, Func<BattleCard, object> orderBy)
        {
            var count = 0;
            foreach (var key in this.keyCollection)
            {
                foreach (var card in this.cardsByKey[key].OrderBy(orderBy))
                {
                    if (count < n)
                    {
                        yield return card;
                        count++;
                    }
                }
            }
        }

        public IEnumerator<BattleCard> GetEnumerator()
            => this.cardsByKey
            .Values
            .SelectMany(c => c)
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
