namespace AspNetCoreMVC.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    using Services;
    using System.Text;

    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ISimpleViewService service;

        public AuthorizationFilter(ISimpleViewService service)
        {
            this.service = service;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //context.HttpContext.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes("Hello from authentication filter"));
        }
    }
}
