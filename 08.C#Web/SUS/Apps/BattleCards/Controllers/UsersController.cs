namespace BattleCards.Controllers
{
    using System.Text.RegularExpressions;
    using System.ComponentModel.DataAnnotations;

    using Services;

    using SUS.HTTP;
    using SUS.MVCFramework;

    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Register()
        {
            if(this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {
            if (this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            if (username == null
                || username.Length < 5
                || username.Length > 20)
            {
                return this.RedirectError("Invalid username! Username should be between 5 and 20 characters inclusive!");
            }

            if (!this.userService.IsUsernameAvailable(username)) 
            {
                return this.RedirectError("Username is unavailable!");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.RedirectError("Only alphanumerical username is accepted!");
            }

            if (email == null
                || !new EmailAddressAttribute().IsValid(email))
            {
                return this.RedirectError("Invalid email!");
            }

            if (!this.userService.IsEmailAvailable(email))
            {
                return this.RedirectError("Email is unavailable!");
            }

            if (password == null
                || password.Length < 6
                || password.Length > 20)
            {
                return this.RedirectError("Invalid password! Password should be between 6 and 20 characters inclusive!");
            }

            if (password != confirmPassword)
            {
                return this.RedirectError("Password should match!");
            }

            this.userService.CreateUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            var userId = this.userService.GetUserId(username, password);

            if (userId == null)
            {
                return this.RedirectError("Invalid username or password!");
            }

            this.SingInUser(userId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignIn())
            {
                return this.RedirectError("Only logged-in users can logout!");
            }

            this.SingOutUser();
            return this.Redirect("/");
        }
    }
}
