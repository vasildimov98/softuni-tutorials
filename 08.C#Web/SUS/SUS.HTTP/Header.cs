namespace SUS.HTTP
{
    using System;

    public class Header
    {
        public Header (string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public Header(string headerLine)
        {
            var lineArgs = headerLine.Split(": ", 2, StringSplitOptions.None);

            var name = lineArgs[0];
            var value = lineArgs[1];

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}