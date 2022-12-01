using System;


namespace TropPizza.Domain.Features.Products
{
    public abstract class Product
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
        }
    }
}