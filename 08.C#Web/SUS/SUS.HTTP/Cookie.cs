namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Cookie(string cookieLine)
        {
            var cookieArgs = cookieLine.Split('=', 2);

            var name = cookieArgs[0];
            var value = cookieArgs[1];

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}
