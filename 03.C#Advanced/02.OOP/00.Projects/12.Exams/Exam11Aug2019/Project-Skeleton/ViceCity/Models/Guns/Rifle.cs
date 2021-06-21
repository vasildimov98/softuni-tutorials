namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;

        private const int COUNT_OF_SHOOT_BULLETS = 5;

        public Rifle(string name)
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {

        }

        public override int Fire()
        {
            if (base.BulletsPerBarrel == 0
                && base.TotalBullets > 0)
            {
                this.ReloadGun();
            }

            if (base.CanFire)
            {
                base.BulletsPerBarrel -= COUNT_OF_SHOOT_BULLETS;
                return COUNT_OF_SHOOT_BULLETS;
            }

            return 0;
        }

        private void ReloadGun()
        {
            base.BulletsPerBarrel = BULLETS_PER_BARREL;

            base.TotalBullets -= BULLETS_PER_BARREL;
        }
    }
}
