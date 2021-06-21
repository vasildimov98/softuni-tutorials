namespace ViceCity.Models.Players
{
    using System;

    using Common;
    using Contracts;
    using Repositories;
    using Guns.Contracts;
    using Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;

            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(null, ExceptionMessages.INVALID_PLAYER_NAME);
                }

                this.name = value;
            }
        }
        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_PLAYER_HEALTH);
                }

                this.lifePoints = value;
            }
        }
        public IRepository<IGun> GunRepository { get; }
        public bool IsAlive => this.LifePoints > 0;

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points > 0)
            {
                this.LifePoints -= points;
            }
            else
            {
                this.LifePoints = 0;
            }
        }
    }
}
