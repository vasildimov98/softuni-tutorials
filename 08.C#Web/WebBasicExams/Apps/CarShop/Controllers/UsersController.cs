namespace CarShop.Controllers
{
    using System.Linq;

    using CarShop.Models.Users;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUsersService usersService;

        public UsersController(
            IValidator validator,
            IUsersService usersService)
        {
            this.validator = validator;
            this.usersService = usersService;
        }

        public HttpResponse Login() => this.View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel inputForm)
        {
            var userId = usersService
                .GetUserId(inputForm.Username, inputForm.Password);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return this.Error("Invalid user input. Try again!");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse Logout(LoginUserFormModel inputForm)
        {
            this.SignOut();

            return this.Redirect("/");
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel inputForm)
        {
            var errors = validator.ValidateRegisterInputForm(inputForm);

            if (errors.Count() > 0)
            {
                return this.Error(errors);
            }

            this.usersService.Create(inputForm.Username,
                inputForm.Email,
                inputForm.Password,
                inputForm.UserType);

            return this.Redirect("/Users/Login");
        }
    }
}
