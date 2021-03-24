namespace SUS.MVC
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
        private const string PageLayoutPath = @"Views\Shared\_Layout.html";
        private const string LayoutPlaceholder = "@RenderBody()";
        private const string NewLayoutPlaceholder = "___Here_Goes_View_Model___";

        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        public HttpRequest Request { get; set; }

        public HttpResponse View(object viewModel = null,
            [CallerMemberName] string viewPath = null)
        {
            if (!viewPath.Contains("/"))
            {
                viewPath = ViewDirectoryName +
                this.GetType().Name.Replace(nameof(Controller), Slash) +
                $"{viewPath}" +
                ViewExtensionName;
            }

            var viewContent = System.IO.File
                .ReadAllText(viewPath);

            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var response = GetResponseWithLayout(viewContent, viewModel);

            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var httpResponse = new HttpResponse(HttpStatusCode.Found);
            httpResponse.Headers.Add(new Header("Location", url));
            return httpResponse;
        }

        public HttpResponse RedirectError(string message)
        {
            var alertHTML = $"<div class=\"alert alert-danger\" role=\"alert\">{message}</div>";
            return this.GetResponseWithLayout(alertHTML);
        }

        private HttpResponse GetResponseWithLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File
                .ReadAllText(PageLayoutPath);

            layout = layout.Replace(LayoutPlaceholder, NewLayoutPlaceholder);

            layout = this.viewEngine.GetHtml(layout, viewModel);

            var responseHtml = layout.Replace(NewLayoutPlaceholder, viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
