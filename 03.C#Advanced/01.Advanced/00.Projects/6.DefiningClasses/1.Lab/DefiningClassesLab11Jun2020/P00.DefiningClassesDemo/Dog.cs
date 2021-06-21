namespace P00.DefiningClassesDemo
{
    using System;
    public class Dog
    {
        // Static Fields
        private static int countOfLegs = 4;

        //  Fields
        private string name;
        private System.Collections.Generic.List<string> toys = new System.Collections.Generic.List<string>();

        //Constructor
        public Dog()
        {

        }
        public Dog(int countOfLegs)
        {
            NumberOfLegs = countOfLegs;
        }

        //Properties
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }

                this.name = value;
            }
        }

        public string Age { get; set; }

        public static int NumberOfLegs
        {
            get => countOfLegs;
            set => countOfLegs = value;
        }

        //Methods
        public string Bark()
        {
            return "Dog is barking";
        }
        public bool IsSpleeping()
        {
            return true;
        }

        // Accessor Method
        public string GetName()
        {
            if (name == null)
            {
                throw new Exception();
            }
            return this.name;
        }

        // Mutator Method:
        public void SetName(string name)
        {
            if (name == null)
            {
                throw new Exception();
            }

            this.name = name;
        }

    }
}
