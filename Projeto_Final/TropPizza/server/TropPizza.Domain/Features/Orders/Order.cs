using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Features.Products;
using TropPizza.Domain.Exceptions.OrderExceptions;
using TropPizza.Domain.Extensions;


namespace TropPizza.Domain.Features.Orders
{
    public class Order
    {
        public Int64 Id { get; set; }
        public OrderStatus StatusEnum { get; set; }

#nullable enable
        public Customer? OrderCustomer { get; set; }
        public List<CartProduct> CartProducts { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string Status
        {
            get { return GetOrderStatusName(); }
        }
        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }

#nullable disable
        public Order()
        {
            CartProducts = new List<CartProduct>();
            StatusEnum = OrderStatus.Pending;
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;

            foreach (CartProduct product in CartProducts)
            {
                totalPrice += product.TotalPrice;
            };

            return totalPrice;
        }

        public bool CanBeDeleted()
        {
            if (StatusEnum == OrderStatus.Finished)
            {
                throw new InvalidDeletion();
            }

            return true;
        }

        private bool CheckValidStatus()
        {
            return Enum.IsDefined(typeof(OrderStatus), StatusEnum) ? true : false;
        }

        private string GetOrderStatusName()
        {
            return StatusEnum.GetDisplayName();
        }

        private bool CheckValidProducts()
        {
            return CartProducts.Count > 0 ? true : false;
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
