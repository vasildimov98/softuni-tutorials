using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    class Engine
    {
        private int speed;
        private int power;

        public Engine(int engineSpeed, int enginePower)
        {
            this.Speed = engineSpeed;
            this.Power = enginePower;
        }
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }
    }
}
