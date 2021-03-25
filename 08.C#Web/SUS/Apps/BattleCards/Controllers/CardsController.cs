namespace BattleCards.Controllers
{
    using System.Linq;

    using SUS.HTTP;
    using SUS.MVCFramework;

    using Models;
    using Models.Data;
    using ViewModels.Card;

    public class CardsController : Controller
    {
        private readonly BattleCardsDbContext context;

        public CardsController(BattleCardsDbContext context)
        {
            this.context = context;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.context.Cards
                .Select(x => new CarViewModel
                {
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Attack = x.Attack,
                    Health = x.Health,
                    Description = x.Description,
                    Type = x.Keyword
                }).ToList();

            return View(cards);
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost("/Cards/Add")]
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

            return this.Redirect("/cards/all");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignIn())
            {
                return this.Redirect("/Users/Login");
            }

            return View();
        }

    }
}
