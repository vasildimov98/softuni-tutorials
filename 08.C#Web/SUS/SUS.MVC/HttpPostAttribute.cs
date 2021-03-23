namespace SUS.MVC
{

    using SUS.HTTP;

    public class HttpPostAttribute : HttpBaseAttribute
    {
        public HttpPostAttribute()
        {
        }

        public HttpPostAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.POST;
    }

}
