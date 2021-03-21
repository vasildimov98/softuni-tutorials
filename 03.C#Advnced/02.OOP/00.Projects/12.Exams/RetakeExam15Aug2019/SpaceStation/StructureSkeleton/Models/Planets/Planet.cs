namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Common;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;

            this.Items = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, ExceptionMessages.INVALID_PLANET_NAME);
                }

                this.name = value;
            }
        }
        public ICollection<string> Items { get; }
    }
}
