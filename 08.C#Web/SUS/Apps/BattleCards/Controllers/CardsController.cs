namespace BattleCards.Controllers
{
    using SUS.MVC;
    using SUS.HTTP;

    using Models;
    using BattleCards.Models.Data;
    using System.Threading.Tasks;

    public class CardsController : Controller
    {
        public HttpResponse All()
        {
            return View();
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
