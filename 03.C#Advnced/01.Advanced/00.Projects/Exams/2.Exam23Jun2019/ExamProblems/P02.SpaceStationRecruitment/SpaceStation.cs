using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private readonly List<Astronaut> data;

        private SpaceStation()
        {
            this.data = new List<Astronaut>();
        }
        public SpaceStation(string name, int capacity)
            : this ()
        {
           this.Name = name;
           this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public void Add(Astronaut astronaut)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var astronaut = this.data
                .FirstOrDefault(a => a.Name == name);

            if (astronaut != null)
            {
                this.data.Remove(astronaut);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data
                .OrderByDescending(a => a.Age)
                .FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data
                .FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
