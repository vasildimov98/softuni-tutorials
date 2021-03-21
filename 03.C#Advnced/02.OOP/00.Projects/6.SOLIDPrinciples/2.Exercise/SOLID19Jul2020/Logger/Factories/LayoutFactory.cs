namespace Logger.Factories
{
    using System;

    using global::Logger.Models.Contracts;
    using global::Logger.Models.Layouts;

    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            if (type == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                return new XmlLayout(); 
            }
            else 
            {
                throw new ArgumentException();
            }
        }
    }
}
