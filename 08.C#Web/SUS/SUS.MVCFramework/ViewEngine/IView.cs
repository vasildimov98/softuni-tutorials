namespace SUS.MVCFramework.ViewEngine
{
    public interface IView
    {
        string GetCleanHtml(object viewModel, string user);
    }
}
