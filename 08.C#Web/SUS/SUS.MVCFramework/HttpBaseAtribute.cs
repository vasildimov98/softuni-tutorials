namespace SUS.MVCFramework
{
    using System;

    using SUS.HTTP;

    public abstract class HttpBaseAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
