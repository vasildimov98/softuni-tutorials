using P03._ShoppingCart;

namespace P03._ShoppingCart_Before.Contracts
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}
