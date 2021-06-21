using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        private Bag()
        {
            this.data = new List<Present>();
        }
        public Bag(string color, int capacity)
            : this()
        {
           this.Color = color;
           this.Capacity = capacity;
        }

        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Present present)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var presentToBeRemoved = this.data
                .FirstOrDefault(p => p.Name == name);

            if (presentToBeRemoved != null)
            {
                this.data.Remove(presentToBeRemoved);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            return this.data
                .OrderByDescending(p => p.Weight)
                .FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return this.data
                .FirstOrDefault(p => p.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
