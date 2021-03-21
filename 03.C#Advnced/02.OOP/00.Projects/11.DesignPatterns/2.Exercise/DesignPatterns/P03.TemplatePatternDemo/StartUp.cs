namespace P03.TemplatePatternDemo
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var sourdough = new Sourdough();
            sourdough.Make();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
