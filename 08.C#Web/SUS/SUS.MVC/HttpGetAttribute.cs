namespace SUS.MVC
{

    using SUS.HTTP;

    public class HttpGetAttribute : HttpBaseAttribute
    {
        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.GET;
    }

}
