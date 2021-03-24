namespace BattleCards.Controllers
{
    using System.Linq;

    using SUS.HTTP;
    using SUS.MVCFramework;

    using Models;
    using ViewModels;
    using Models.Data;

    public class CardsController : Controller
    {
        private readonly BattleCardsDbContext context;

        public CardsController(BattleCardsDbContext context)
        {
            this.context = context;
        }

        public HttpResponse All()
        {
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
        public HttpResponse DoAdd()
        {
            if (this.Request.FormData["name"].Length < 5)
            {
                return this.RedirectError("Name should be at least 5 length and max 15 length");
            }

            var card = new Card
            {
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
            };

            this.context.Cards.Add(card);

            this.context.SaveChanges();

            return this.Redirect("/cards/all");
        }

        public HttpResponse Collection()
        {
            return View();
        }

    }
}
