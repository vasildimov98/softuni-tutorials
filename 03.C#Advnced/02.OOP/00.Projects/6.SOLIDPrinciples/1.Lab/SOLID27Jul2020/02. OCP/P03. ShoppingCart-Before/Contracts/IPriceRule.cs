namespace P03._ShoppingCart_Before.Contracts
{
    using P03._ShoppingCart;

    public interface IPriceRule
    {
        bool IsMatch(OrderItem item);

        decimal CalculatePrice(OrderItem item);
    }
}
