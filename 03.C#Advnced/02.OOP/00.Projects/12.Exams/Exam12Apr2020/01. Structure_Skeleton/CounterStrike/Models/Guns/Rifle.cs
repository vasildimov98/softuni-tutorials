namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLET_STRIKE = 10;
        private const int ZERO_BULLET_STRIKE = 0;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        public override int Fire()
        {
            if (base.BulletsCount == 0)
            {
                return ZERO_BULLET_STRIKE;
            }

            base.BulletsCount -= BULLET_STRIKE;

            return BULLET_STRIKE;
        }
    }
}
