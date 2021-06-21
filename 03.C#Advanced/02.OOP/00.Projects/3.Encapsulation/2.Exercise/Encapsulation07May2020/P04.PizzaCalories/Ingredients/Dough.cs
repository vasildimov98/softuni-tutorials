namespace P04.PizzaCalories.Ingredients
{
    using System;
    using System.Runtime.CompilerServices;

    public class Dough
    {
        private const string TYPE = "crispy chewy homemade white wholegrain";
        private const double WEIGHT_PER_GRAMS = 2;
        private const double WHITE = 1.5;
        private const double WHOLEGRAIN = 1.0;
        private const double CRIPSY = 0.9;
        private const double CHEWY = 1.1;
        private const double HOMEMADE = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double CaloriesPerGram => this.CaloriesPerGrams();

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                Validator(value);
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                Validator(value);
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double CaloriesPerGrams()
        {
            return (WEIGHT_PER_GRAMS * this.Weight)
                * this.GetGramsFromFlour(this.FlourType)
                * this.GetGramsOfBackingTechnique(this.BakingTechnique);
        }
        private double GetGramsFromFlour(string flourType)
        {
            if (flourType.ToLower() == "white")
            {
                return WHITE;
            }
            else
            {
                return WHOLEGRAIN;
            }
        }
        private double GetGramsOfBackingTechnique(string bakingTechniqueType)
        {
            if (bakingTechniqueType.ToLower() == "crispy")
            {
                return CRIPSY;
            }
            else if (bakingTechniqueType.ToLower() == "chewy")
            {
                return CHEWY;
            }
            else 
            {
                return HOMEMADE;
            }
           
        }

        private void Validator(string value)
        {
            if (!TYPE.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
}
