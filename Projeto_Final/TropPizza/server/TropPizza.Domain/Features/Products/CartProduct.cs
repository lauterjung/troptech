namespace TropPizza.Domain.Features.Products
{
    public class CartProduct : Product
    {
        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

        public CartProduct()
        {
        }

        public double CalculateTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}