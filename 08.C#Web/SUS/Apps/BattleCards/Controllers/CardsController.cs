namespace BattleCards.Controllers
{
    using System.Linq;

    using SUS.MVC;
    using SUS.HTTP;

    using Models;
    using ViewModels;
    using Models.Data;

    public class CardsController : Controller
    {
        public HttpResponse All()
        {
            var context = new BattleCardsDbContext();

            var cards = context.Cards
                .Select(x => new CarViewModel
                {
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Attack = x.Attack,
                    Health = x.Health,
                    Description = x.Description,
                    Type = x.Keyword
                }).ToList();

            return View(new AllCarViewModel {Cards = cards });
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var card = new Card
            {
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
            };

            var context = new BattleCardsDbContext();

            context.Cards.Add(card);

            context.SaveChanges();

            return this.Redirect("/cards/all");
        }

        public HttpResponse Collection()
        {
            return View();
        }

    }
}
