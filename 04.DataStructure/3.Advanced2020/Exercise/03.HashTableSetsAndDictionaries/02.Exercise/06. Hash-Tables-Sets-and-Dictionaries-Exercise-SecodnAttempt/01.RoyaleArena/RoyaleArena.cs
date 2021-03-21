namespace _01.RoyaleArena
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using Helpers;
    using Interfaces;

    public class RoyaleArena : IArena
    {
        const string INVALID_ID_MSG = "There is no such card with corresponding id in the collection!";
        const string INVALID_TYPE_MSG = "There is no such card with corresponding type in the collection!";
        const string INVALID_NAME_MSG = "There is no such card with corresponding name in the collection!";
        const string NO_SUCH_COLLECTION_FOUND = "There are not found any cards between given range in the collection!";
        const string INVALID_N_COUNT_MSG = "Trying to find more cards than actually having in the collection";

        private readonly Dictionary<int, BattleCard> packOfCards;
        private readonly Dictionary<CardType, CardCollection> cardsByTypeSortedByDamage;
        private readonly Dictionary<string, CardCollection> cardsByNameSortedByDamage;
        private readonly CardCollection cardCollectionOrderedBySwag;

        public RoyaleArena()
        {
            this.packOfCards = new Dictionary<int, BattleCard>();
            this.cardsByTypeSortedByDamage = new Dictionary<CardType, CardCollection>();
            this.cardsByNameSortedByDamage = new Dictionary<string, CardCollection>();
            this.cardCollectionOrderedBySwag = new CardCollection(new SwagKeyCollection());
        }

        public int Count => this.packOfCards.Count;

        public void Add(BattleCard card)
        {
            this.packOfCards[card.Id] = card;
            this.AddCardToCorrespondingCollection<DamageKeyCollection>(card, this.cardsByTypeSortedByDamage, c => c.Type);
            this.AddCardToCorrespondingCollection<SwagKeyCollection>(card, this.cardsByNameSortedByDamage, c => c.Name);
            this.cardCollectionOrderedBySwag.AddCard(card);
        }

        public bool Contains(BattleCard card)
            => this.packOfCards.ContainsKey(card.Id);

        public void ChangeCardType(int id, CardType type)
        {
            this.ValidateCardKey(this.packOfCards, id, INVALID_ID_MSG);
            var card = this.packOfCards[id];
            card.Type = type;
            this.packOfCards[id] = card;
        }

        public BattleCard GetById(int id)
        {
            this.ValidateCardKey(this.packOfCards, id, INVALID_ID_MSG);
            return this.packOfCards[id];
        }

        public void RemoveById(int id)
        {
            this.ValidateCardKey(this.packOfCards, id, INVALID_ID_MSG);
            var card = this.packOfCards[id];

            this.RemoveCardToCorrespondingCollection(card, this.cardsByTypeSortedByDamage, c => c.Type);
            this.RemoveCardToCorrespondingCollection(card, this.cardsByNameSortedByDamage, c => c.Name);
            this.cardCollectionOrderedBySwag.RemoveCard(card);
            this.packOfCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            this.ValidateCardKey(this.cardsByTypeSortedByDamage, type, INVALID_TYPE_MSG);
            return this.cardsByTypeSortedByDamage[type];
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            this.ValidateCardKey(this.cardsByTypeSortedByDamage, type, INVALID_TYPE_MSG);
            return this.cardsByTypeSortedByDamage[type]
                .GetCardsBetweenRange(lo, hi)
                .OrderBy(c => c);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            this.ValidateCardKey(this.cardsByTypeSortedByDamage, type, INVALID_TYPE_MSG);

            var lowerRange = this.cardsByTypeSortedByDamage[type].MinKey;

            var collectionInRange = this.cardsByTypeSortedByDamage[type]
                .GetCardsBetweenRange(lowerRange, damage);

            if (collectionInRange.Count() == 0)
                throw new InvalidOperationException(NO_SUCH_COLLECTION_FOUND);

            return collectionInRange
                .OrderBy(c => c);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            this.ValidateCardKey<string>(this.cardsByNameSortedByDamage, name, INVALID_NAME_MSG);
            return this.cardsByNameSortedByDamage[name];
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            this.ValidateCardKey<string>(this.cardsByNameSortedByDamage, name, INVALID_NAME_MSG);
            return this.cardsByNameSortedByDamage[name]
                .GetCardsBetweenRange(lo, hi)
                .OrderBy(c => c);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.Count)
                throw new InvalidOperationException(INVALID_N_COUNT_MSG);

            return this.cardCollectionOrderedBySwag
                .FindFirstNCards(n, c => c.Id);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return this.cardCollectionOrderedBySwag
                .GetCardsBetweenRange(lo, hi);
        }

        public IEnumerator<BattleCard> GetEnumerator()
            => this.packOfCards
            .Values
            .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void AddCardToCorrespondingCollection<T>(BattleCard card, IDictionary collection, Func<ICard, object> getKey)
                where T : KeyCollection<double>, new()
        {
            var cardKey = getKey(card);
            if (!collection.Contains(cardKey))
                collection[cardKey] = new CardCollection(new T());
            (collection[cardKey] as CardCollection).AddCard(card);
        }

        private void RemoveCardToCorrespondingCollection(BattleCard card, IDictionary collection, Func<ICard, object> getKey)
        {
            var cardKey = getKey(card);
            var cardCollection = (collection[cardKey] as CardCollection);
            cardCollection.RemoveCard(card);
            if (cardCollection.Count == 0)
                collection.Remove(cardKey);
        }

        private void ValidateCardKey<T>(IDictionary collection, T key, string errorMsg)
        {
            if (!collection.Contains(key))
                throw new InvalidOperationException(errorMsg);
        }
    }
}