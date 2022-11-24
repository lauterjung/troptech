using System;

namespace TropPizza.Domain.Features.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

        public Product(string name)
        {
            IsActive = true;
            Name = name;
        }

        public Product()
        {
        }

        private bool CheckValidExpirationDate(DateTime expirationDate)
        {
            return expirationDate > DateTime.Now.Date ? true : false;
        }

        private bool CheckValidQuantity(int quantity)
        {
            return quantity >= 0 ? true : false;
        }

        public double CalculateTotalPrice()
        {
            return Quantity * UnitPrice;
        }

        // public void Activate()
        // {
        //     IsActive = true;
        // }

        // public void Deactivate()
        // {
        //     IsActive = false;
        // }
    }
}