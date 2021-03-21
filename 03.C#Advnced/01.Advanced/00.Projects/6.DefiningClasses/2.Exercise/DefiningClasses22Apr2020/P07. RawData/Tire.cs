using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    class Tire
    {
        private double pressure;
        private int age;

        public Tire(double tirePressure, int tireAge)
        {
            this.Pressure = tirePressure;
            this.Age = tireAge;
        }
        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}
