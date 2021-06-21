namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;

        private const int COUNT_OF_SHOOT_BULLETS = 1;

        public Pistol(string name)
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
