namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DEF_COMFOTRT = 1;
        private const decimal DEF_PRICE = 5m;
        public Ornament()
            : base(DEF_COMFOTRT, DEF_PRICE)
        {

        }
    }
}
