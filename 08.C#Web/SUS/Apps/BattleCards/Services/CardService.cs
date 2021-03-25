namespace BattleCards.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Models.Data;
    using ViewModels.Card;

    public class CardService : ICardService
    {
        private BattleCardsDbContext context;

        public CardService(BattleCardsDbContext context)
        {
            this.context = context;
        }

        public int AddCard(AddCarInputViewModel model)
        {
            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
            };

            this.context.Cards.Add(card);

            this.context.SaveChanges();

            return card.Id;
        }

        public void AddToCollection(string userId, int cardId)
        {
            if (this.context.UsersCards
                .Any(x => x.CardId == cardId && x.UserId == userId))
                return;

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = userId
            };

            this.context.UsersCards.Add(userCard);

            context.SaveChanges();
        }

        public void RemoveFromCollection(string userId, int cardId)
        {
            var userCardToRemove = this.context.UsersCards
                .FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCardToRemove != null)
            {
                this.context.UsersCards.Remove(userCardToRemove);

                context.SaveChanges();
            }
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            return this.context.Cards
               .Select(x => new CarViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   ImageUrl = x.ImageUrl,
                   Attack = x.Attack,
                   Health = x.Health,
                   Description = x.Description,
                   Type = x.Keyword
               })
               .ToList();
        }

        public IEnumerable<CarViewModel> GetMyCollection(string userId)
        {
            return context.UsersCards
                 .Where(x => x.UserId == userId)
                 .Select(x => new CarViewModel
                 {
                     Id = x.CardId,
                     Name = x.Card.Name,
                     ImageUrl = x.Card.ImageUrl,
                     Attack = x.Card.Attack,
                     Health = x.Card.Health,
                     Description = x.Card.Description,
                     Type = x.Card.Keyword
                 })
                 .ToList();
        }

    }
}
