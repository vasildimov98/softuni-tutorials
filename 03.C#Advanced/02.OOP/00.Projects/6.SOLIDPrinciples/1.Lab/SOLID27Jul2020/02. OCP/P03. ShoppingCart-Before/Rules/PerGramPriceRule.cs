namespace P03._ShoppingCart_Before.Rules
{
    using Contracts;
    using P03._ShoppingCart;

    public class PerGramPriceRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 4m / 1000;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }
    }
}
