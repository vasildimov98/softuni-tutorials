namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int DEF_CAPACITY = 50;
        public FreshwaterAquarium(string name)
            : base(name, DEF_CAPACITY)
        {

        }
    }
}
