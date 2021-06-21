namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLET_STRIKE = 1;
        private const int ZERO_BULLET_STRIKE = 0;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (base.BulletsCount == 0)
            {
                return ZERO_BULLET_STRIKE;
            }

            base.BulletsCount--;

            return BULLET_STRIKE;
        }
    }
}
