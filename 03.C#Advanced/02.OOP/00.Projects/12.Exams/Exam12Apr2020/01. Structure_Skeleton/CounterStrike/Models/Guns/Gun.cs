namespace CounterStrike.Models.Guns
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Gun : IGun
    {
        private const int BULLETS_MIN_COUNT = 0;
        
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bulletsCount;
            protected set
            {
                if (value < BULLETS_MIN_COUNT)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletsCount = value;
            }
        }

        public abstract int Fire();
    }
}
