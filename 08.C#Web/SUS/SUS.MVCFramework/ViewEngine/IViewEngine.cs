namespace SUS.MVCFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string template, object viewModel);
    }
}
