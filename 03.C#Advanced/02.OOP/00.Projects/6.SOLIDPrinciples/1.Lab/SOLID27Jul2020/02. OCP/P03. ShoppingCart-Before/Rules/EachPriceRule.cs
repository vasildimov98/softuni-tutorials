namespace P03._ShoppingCart_Before.Rules
{
    using Contracts;
    using P03._ShoppingCart;

    public class EachPriceRule : IPriceRule
    {
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 5m;
        }

        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("EACH");
        }
    }
}
