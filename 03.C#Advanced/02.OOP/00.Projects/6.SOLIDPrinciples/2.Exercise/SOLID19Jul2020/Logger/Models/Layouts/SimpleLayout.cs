namespace Logger.Models.Layouts
{
    using global::Logger.Models.Contracts;
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
