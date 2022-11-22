namespace TropPizza.Domain.Features.Products
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double? TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

        public Product(string name)
        {
            Name = name;
        }

        public Product()
        {
            
        }

        public double CalculateTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}