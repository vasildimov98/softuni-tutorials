namespace SUS.MVC.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string template, object viewModel);
    }
}
