namespace P03._ShoppingCart_Before
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using P03._ShoppingCart;
    using P03._ShoppingCart_Before.Rules;

    public class PriceCalculator : IPricingCalculator
    {
        private readonly ICollection<IPriceRule> priceRulers;

        public PriceCalculator()
        {
            this.priceRulers = new List<IPriceRule>()
            {
                new EachPriceRule(),
                new PerGramPriceRule(),
                new SpecialPriceRule(),
                new BuyFourGetOneFree()
            };
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return this.priceRulers
                .First(p => p.IsMatch(item))
                .CalculatePrice(item);
        }
    }
}
