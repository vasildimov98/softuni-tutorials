namespace PlayersAndMonsters.Models.Cards
{
    using System;

    using Common;
    using Contracts;

    public class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardName);
                }

                this.name = value;
            }
        }
        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                if (damagePoints < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardDamagePoints);
                }

                this.damagePoints = value;
            }
        }
        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                if (healthPoints < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardHealthPoints);
                }

                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ConstantMessages.CardReportInfo, this.Name, this.DamagePoints);
        }
    }
}
