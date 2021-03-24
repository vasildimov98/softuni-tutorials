namespace SUS.MVCFramework
{
    using System.Text;
    using System.Runtime.CompilerServices;

    using HTTP;
    using ViewEngine;

    public abstract class Controller
    {
        private const string Slash = @"\";
        private const string ViewDirectoryName = @"Views\";
        private const string ViewExtensionName = ".cshtml";
        private const string PageLayoutPath = @"Views\Shared\_Layout.cshtml";
        private const string LayoutPlaceholder = "@RenderBody()";
        private const string NewLayoutPlaceholder = "___Here_Goes_View_Model___";
        private const string UserIdSessionName = "UserId";

        private SusViewEngine viewEngine;

        public Controller()
        {
            viewEngine = new SusViewEngine();
        }

        public HttpRequest Request { get; set; }

        protected HttpResponse View(object viewModel = null,
            [CallerMemberName] string viewPath = null)
        {
            if (!viewPath.Contains("/"))
            {
                viewPath = ViewDirectoryName +
                GetType().Name.Replace(nameof(Controller), Slash) +
                $"{viewPath}" +
                ViewExtensionName;
            }

            var viewContent = System.IO.File
                .ReadAllText(viewPath);

            viewContent = viewEngine.GetHtml(viewContent, viewModel, this.GetUserId());

            var response = GetResponseWithLayout(viewContent, viewModel);

            return response;
        }

        protected HttpResponse Redirect(string url)
        {
            var httpResponse = new HttpResponse(HttpStatusCode.Found);
            httpResponse.Headers.Add(new Header("Location", url));
            return httpResponse;
        }

        protected HttpResponse RedirectError(string message)
        {
            var alertHTML = $"<div class=\"alert alert-danger\" role=\"alert\">{message}</div>";
            return GetResponseWithLayout(alertHTML);
        }

        protected void SingInUser(string userId)
        {
            this.Request.Session[UserIdSessionName] = userId;
        }

        protected void SingOutUser()
        {
            this.Request.Session[UserIdSessionName] = null;
        }

        protected bool IsUserLoggedIn()
            => this.Request.Session.ContainsKey(UserIdSessionName)
            && this.Request.Session[UserIdSessionName] != null;

        protected string GetUserId()
            => this.Request.Session.ContainsKey(UserIdSessionName) ?
            this.Request.Session[UserIdSessionName] : null;

        private HttpResponse GetResponseWithLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File
                .ReadAllText(PageLayoutPath);

            layout = layout.Replace(LayoutPlaceholder, NewLayoutPlaceholder);

            layout = viewEngine.GetHtml(layout, viewModel, this.GetUserId());

            var responseHtml = layout.Replace(NewLayoutPlaceholder, viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
