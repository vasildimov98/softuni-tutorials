namespace BattleCards.Services
{
    using System.Collections.Generic;

    using ViewModels.Card;

    public interface ICardService
    {
        public IEnumerable<CarViewModel> GetAll();

        public IEnumerable<CarViewModel> GetMyCollection(string userId);

        public int AddCard(AddCarInputViewModel model);

        public void AddToCollection(string userId, int cardId);

        public void RemoveFromCollection(string userId, int cardId);
    }
}
