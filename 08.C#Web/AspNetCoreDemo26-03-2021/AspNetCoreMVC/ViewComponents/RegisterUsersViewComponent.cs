namespace AspNetCoreMVC.ViewComponents
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Data;
    using AspNetCoreMVC.ViewModels.ViewComponents;

    [ViewComponent(Name = "RegisterUsers")]
    public class RegisterUsersViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public RegisterUsersViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke(string text)
        {
            var usersCount = this.context.Users.Count();

            return this.View(new RegisterUserCountViewModel { Text = text, Count = usersCount });
        }
    }
}
