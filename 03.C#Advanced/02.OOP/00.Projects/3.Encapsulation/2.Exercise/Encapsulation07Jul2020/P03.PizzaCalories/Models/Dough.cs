namespace P03.PizzaCalories
{
    using System;

    using P03.PizzaCalories.Contracts;

    public class Dough
    {
        private const string TYPES = "WHITE WHOLEGRAIN";
        private const string TECHNIQUES = "CRISPY HOMEMADE CHEWY";

        private const string WHITE_TYPE = "WHITE";
        private const string CRIPSY_TECHNIQUE = "CRISPY";
        private const string CHEWY_TECHNIQUE = "CHEWY";

        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 200;
        private const int CALORIES_PER_GRAM = 2;

        private const double WHITE = 1.5;
        private const double WHOLEGRAIN = 1.0;
        private const double CRISPY = 0.9;
        private const double CHEWY = 1.1;
        private const double HOMEMADE = 1.0;

        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type,
            string bakingTechnique,
            double weight)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!TYPES.Contains(value.ToUpper()))
                {
                    this.ThrowArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                this.type = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!TECHNIQUES.Contains(value.ToUpper()))
                {
                    this.ThrowArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRangeOfWeightOfDough);
                }

                this.weight = value;
            }
        }
        public double CaloriesPerGram
            => this.CalculateCalories();

        private double CalculateCalories()
        {
            var caloriesPerGram = this.Weight * CALORIES_PER_GRAM;

            if (WHITE_TYPE.Contains(this.Type.ToUpper()))
            {
                caloriesPerGram *= WHITE;
            }
            else
            {
                caloriesPerGram *= WHOLEGRAIN;
            }

            if (CRIPSY_TECHNIQUE.Contains(this.BakingTechnique.ToUpper()))
            {
                caloriesPerGram *= CRISPY;
            }
            else if (CHEWY_TECHNIQUE.Contains(this.BakingTechnique.ToUpper()))
            {
                caloriesPerGram *= CHEWY;

            }
            else
            {
                caloriesPerGram *= HOMEMADE;
            }

            return caloriesPerGram;
        }
        private void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message);
        }
    }
}
