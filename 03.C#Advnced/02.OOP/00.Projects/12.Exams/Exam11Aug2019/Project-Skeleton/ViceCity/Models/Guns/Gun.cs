namespace ViceCity.Models.Guns
{
    using System;

    using Common;
    using Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_GUN_NAME);
                }

                this.name = value;
            }
        }
        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_BULLENTS_AMOUNT);
                }

                this.bulletsPerBarrel = value;
            }
        }
        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_TOTAL_BULLETS);
                }

                this.totalBullets = value;
            }
        }
        public bool CanFire => this.BulletsPerBarrel > 0;

        public abstract int Fire();
    }
}
