using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.Weight = cargoWeight;
            this.Type = cargoType;
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}
