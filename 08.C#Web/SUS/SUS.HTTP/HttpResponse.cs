namespace SUS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers = new List<Header>();
            this.Cookies = new List<ResponseCookie>();
        }

        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            this.Cookies = new List<ResponseCookie>();

            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            this.Body = body;
            this.StatusCode = statusCode;

            this.Headers = new List<Header>
            {
                { new Header(HttpConstant.ContentTypeHeader, contentType) },
                { new Header(HttpConstant.ContentLengthHeader, body.Length.ToString()) }
            };
        }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + HttpConstant.NewLine);

            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstant.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseBuilder.Append(cookie.ToString() + HttpConstant.NewLine);
            }

            responseBuilder.Append(HttpConstant.NewLine);

            return responseBuilder.ToString();
        }
    }
}
