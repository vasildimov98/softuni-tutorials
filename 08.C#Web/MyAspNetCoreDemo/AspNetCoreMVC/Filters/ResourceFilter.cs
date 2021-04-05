namespace AspNetCoreMVC.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
