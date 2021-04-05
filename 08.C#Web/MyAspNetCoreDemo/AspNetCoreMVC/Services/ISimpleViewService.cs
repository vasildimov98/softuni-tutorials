namespace AspNetCoreMVC.Services
{
    public interface ISimpleViewService
    {
        string GetShortText(string text, int length = 10);
    }
}
