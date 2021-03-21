using System;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;

namespace P00.DefiningClassesDemo
{
    public class Dice
    {
        // access modifier (always private) + type (string, int, ect..) + name;
        private int size;
        private string type;
        private int sides;
        private int[] rollFrequency;
        private Person owner;
        private Random random;

        // Constructors
        private Dice()
        {
            this.owner = new Person("Vasko", 22);
            this.rollFrequency = new int[100];
            this.random = new Random();
        }

        public Dice(int sides)
            : this()
        {
            this.Sides = sides;
        }

        public Dice(int size, string type, int sides)
            : this(sides)
        {
            this.size = size;
            this.type = type;
        }

        public int Sides
        {
            get => this.sides;
            set => this.sides = value;
        }

        public int Roll()
        {
            int rollResult = random.Next(1, this.Sides + 1);

            return rollResult;
        }
    }
}
