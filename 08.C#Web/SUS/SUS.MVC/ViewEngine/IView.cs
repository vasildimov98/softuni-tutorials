namespace SUS.MVC.ViewEngine
{
    public interface IView
    {
        string GetCleanHtml(object viewModel);
    }
}
