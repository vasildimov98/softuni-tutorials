﻿namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double OVERALL_PERFORMANCE_MULT = 1.05;

        public PowerSupply(int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
            : base(id,
                  manufacturer,
                  model,
                  price,
                  overallPerformance * OVERALL_PERFORMANCE_MULT,
                  generation)
        {

        }
    }
}
