namespace Git.Controllers
{
    using System.Linq;

    using Git.Models.Users;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private IValidator validator;
        private IUsersService usersService;

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

            return this.Redirect("/Repositories/All");
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
            var errors = validator.ValidateRegisterFormModel(inputForm);

            if (errors.Any())
            {
                return this.Error(errors);
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
