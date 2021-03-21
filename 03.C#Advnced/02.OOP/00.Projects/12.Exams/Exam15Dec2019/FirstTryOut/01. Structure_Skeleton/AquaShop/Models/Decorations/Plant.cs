namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DEF_COMFOTRT = 5;
        private const decimal DEF_PRICE = 10m;

        public Plant()
            : base(DEF_COMFOTRT, DEF_PRICE)
        {

        }
    }
}
