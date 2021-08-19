namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;
    using System.Linq;

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
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        public HttpResponse Register() => this.View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel inputForm)
        {
            var errors = validator
                .ValidateRegisterFormModel(inputForm);

            if (errors.Any())
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService
                .CreateUser(
                inputForm.Username,
                inputForm.Email,
                inputForm.Password);

            return this.Redirect("/Users/Login");
        }
    }
}
