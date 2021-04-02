namespace AspNetCoreMVC.Filters
{
    using AspNetCoreMVC.Services;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class SampleActionFilter : IActionFilter
        
    {
        private readonly ISimpleViewService simpleViewService;

        public SampleActionFilter(ISimpleViewService simpleViewService)
        {
            this.simpleViewService = simpleViewService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("someheader", new string[] { simpleViewService.GetShortText("Super looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong text!!!!") });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    // do things before 
        //    var result = await next();
        //    //After
        //    throw new System.NotImplementedException();
        //}
    }
}
