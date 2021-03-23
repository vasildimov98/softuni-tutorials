using System.Text;

namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value, string path = "/")
            : base(name, value)
        {
            this.Path = path;
        }

        public bool HttpOnly { get; set; }

        public int MaxAge { get; set; }

        public string Path { get; set; }

        // Set-Cookie: SSID=Ap4P…GTEq; Domain=foo.com; Path=/; Max-Age=2; Expires=Wed, 13 Jan 2021 22:23:01 GMT; Secure; HttpOnly
        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"Set-Cookie: {base.ToString()};");

            if (this.MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append($" {nameof(this.HttpOnly)};");
            }

            return cookieBuilder.ToString();
        }
    }
}
