namespace SUS.MVCFramework
{

    using SUS.HTTP;

    public class HttpGetAttribute : HttpBaseAttribute
    {
        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
        {
            Url = url;
        }

        public override HttpMethod Method => HttpMethod.GET;
    }

}
