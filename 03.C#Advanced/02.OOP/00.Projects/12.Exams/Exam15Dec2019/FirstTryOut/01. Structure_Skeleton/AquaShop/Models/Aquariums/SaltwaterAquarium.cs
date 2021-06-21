namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int DEF_CAPACITY = 25;
        public SaltwaterAquarium(string name)
            : base(name, DEF_CAPACITY)
        {

        }
    }
}
