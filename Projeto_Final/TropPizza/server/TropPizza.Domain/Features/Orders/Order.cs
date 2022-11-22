using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Domain.Features.Orders
{
    public class Order
    {
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }

        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

        public Order(Customer customer, List<Product> products)
        {
            Customer = customer;
            Products = products;
            Status = OrderStatus.Pending; // Inactive?
            OrderDate = DateTime.Now;
        }

        public Order()
        {
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (Product product in Products)
            {
                totalPrice += product.CalculateTotalPrice();
            };

            return totalPrice;
        }

        public double UseFidelityDiscount()
        {
            throw new NotImplementedException();
        }

    }
}
