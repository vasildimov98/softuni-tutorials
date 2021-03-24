namespace BattleCards.Controllers
{
    using Services;

    using SUS.HTTP;
    using SUS.MVCFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UsersController : Controller
    {
        private UserService userService;

        public UsersController()
        {
            this.userService = new UserService();
        }

        public HttpResponse Register()
        {
            if(this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            return View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            if (this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            var username = this.Request.FormData["username"];
            var email = this.Request.FormData["email"];
            var password = this.Request.FormData["password"];
            var confirmPassword = this.Request.FormData["confirmPassword"];

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

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            if (this.IsUserSignIn())
            {
                this.Redirect("/Cards/All");
            }

            var username = this.Request.FormData["username"];
            var password = this.Request.FormData["password"];

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
