namespace SUS.HTTP
{
    using System;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class HttpRequest
    {
        private readonly static Dictionary<string, Dictionary<string, string>> Sessions
            = new Dictionary<string, Dictionary<string, string>>();

        public HttpRequest(string requestAsString)
        {
            this.FormData = new Dictionary<string, string>();
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            this.HttpRequestParser(requestAsString);
        }

        public string Path { get; set; }

        public string Body { get; set; }

        public Dictionary<string, string> Session { get; set; }

        public Dictionary<string, string> FormData { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        private void HttpRequestParser(string requestAsString)
        {
            if (string.IsNullOrWhiteSpace(requestAsString))
                return;

            var requestLines = requestAsString
                            .Split(HttpConstant.NewLine, StringSplitOptions.None);

            var headerStartLine = requestLines[0];

            var startLineArgs = headerStartLine.Split(' ');

            var method = startLineArgs[0];
            var path = startLineArgs[1];

            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), method);
            this.Path = path;

            var bodyBuilder = new StringBuilder();
            this.ProcessRquestLines(requestLines, bodyBuilder);
            this.ProcessCookieHeader();

            var sessionCookie = this.Cookies
                .FirstOrDefault(x => x.Name == HttpConstant.SessionCookieName);

            if (sessionCookie == null)
            {
                var sessionId = Guid.NewGuid().ToString();
                this.Session = new Dictionary<string, string>();
                Sessions[sessionId] = this.Session;
                this.Cookies.Add(new Cookie(HttpConstant.SessionCookieName, sessionId));
            }
            else if (!Sessions.ContainsKey(sessionCookie.Value))
            {
                this.Session = new Dictionary<string, string>();
                Sessions[sessionCookie.Value] = this.Session;
            }
            else
            {
                this.Session = Sessions[sessionCookie.Value];
            }

            this.Body = bodyBuilder.ToString();
            this.WriteFormData();
        }

        private void WriteFormData()
        {
            var parameters = this.Body
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var parameter in parameters)
            {
                var kvpArgs = parameter
                    .Split('=', 2, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var key = WebUtility.UrlDecode(kvpArgs[0]);
                var value = WebUtility.UrlDecode(kvpArgs[1]);

                if (!this.FormData.ContainsKey(key))
                {
                    this.FormData[key] = value;
                }
            }
        }

        private void ProcessRquestLines(string[] requestLines, StringBuilder bodyBuilder)
        {
            var currLineIndex = 1;
            var isHeader = true;
            while (currLineIndex < requestLines.Length)
            {
                var currLine = requestLines[currLineIndex++];

                if (string.IsNullOrWhiteSpace(currLine))
                {
                    isHeader = false;
                    continue;
                }

                if (isHeader)
                {
                    this.Headers.Add(new Header(currLine));
                }
                else
                {
                    bodyBuilder.AppendLine(currLine);
                }
            }
        }

        private void ProcessCookieHeader()
        {
            if (this.Headers.Any(x => x.Name == HttpConstant.RequestCookieHeader))
            {
                var cookiesAsString = this.Headers
                        .FirstOrDefault(x => x.Name == HttpConstant.RequestCookieHeader).Value;

                var cookiesLines = cookiesAsString
                        .Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookieLine in cookiesLines)
                {
                    this.Cookies.Add(new Cookie(cookieLine));
                }
            }
        }
    }
}
