namespace BattleCards.Controllers
{
    using System.Linq;

    using SUS.HTTP;
    using SUS.MVCFramework;

    using Models;
    using Services;
    using Models.Data;
    using ViewModels.Card;

    public class CardsController : Controller
    {
        private readonly ICardService service;

        public CardsController(ICardService service)
        {
            this.service = service;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = service.GetAll();

            return View(cards);
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarInputViewModel model)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name == null
                || model.Name.Length < 5
                || model.Name.Length > 15)
            {
                return this.RedirectError("Invalid Name! Name should be at least 5 length and max 15 length");
            }

            if (model.Image == null)
            {
                return this.RedirectError("Image is required!");
            }

            if (model.Keyword == null)
            {
                return this.RedirectError("Keyword is required!");
            }

            if (model.Attack < 0)
            {
                return this.RedirectError("Attack cannot be negative!");
            }

            if (model.Health < 0)
            {
                return this.RedirectError("Attack cannot be negative!");
            }

            if (model.Description == null
                || model.Description.Length > 200)
            {
                return this.RedirectError("Invalid description!");
            }

            var cardId = service.AddCard(model);

            var userId = this.GetUserId();
            service.AddToCollection(userId, cardId);

            return this.Redirect("/cards/all");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            service.AddToCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            service.RemoveFromCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var collection = service.GetMyCollection(userId);

            return View(collection);
        }

    }
}
