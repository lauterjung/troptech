using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Features.Products;
using TropPizza.Domain.Exceptions.OrderExceptions;

namespace TropPizza.Domain.Features.Orders
{
    public class Order
    {
        public Int64 Id { get; set; }
        public OrderStatus Status { get; set; }
#nullable enable
        public Customer? OrderCustomer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

#nullable disable
        public Order()
        {
            Products = new List<Product>();
            Status = OrderStatus.Pending;
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (Product product in Products)
            {
                totalPrice += product.TotalPrice;
            };

            return totalPrice;
        }

        public bool CanBeDeleted()
        {
            if (Status == OrderStatus.Finished)
            {
                throw new InvalidDeletion();
            }

            return true;
        }

        private bool CheckValidStatus()
        {
            return Enum.IsDefined(typeof(OrderStatus), Status) ? true : false;
        }

        private bool CheckValidProducts()
        {
            return Products.Count > 0 ? true : false;
        }

        public bool Validate()
        {
            if (CheckValidStatus() == false)
            {
                throw new InvalidStatus();
            }
            if (CheckValidProducts() == false)
            {
                throw new InvalidProducts();
            }

            return true;
        }
    }
}
