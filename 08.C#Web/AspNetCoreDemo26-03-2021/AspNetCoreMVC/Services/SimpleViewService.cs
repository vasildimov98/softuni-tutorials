namespace AspNetCoreMVC.Services
{
    public class SimpleViewService : ISimpleViewService
    {
        public string GetShortText(string text, int length = 10)
        {
            if (text == null) return text;

            if (text.Length == length) return text;

            return text.Substring(0, length) + "...";
        }
    }
}
