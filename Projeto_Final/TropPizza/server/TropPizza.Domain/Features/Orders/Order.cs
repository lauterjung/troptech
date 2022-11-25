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
        public string? CustomerCpf { get; set; } // ?
        public Customer? Customer { get; set; } // ?
        public List<Product> Products { get; set; }
        public DateTime OrderDateTime { get; set; }

        public double TotalPrice
        {
            get { return CalculateTotalPrice(); }
        }
#nullable disable
        // public Order(Customer customer, List<Product> products)
        // {
        //     Customer = customer;
        //     Products = products;
        //     Status = OrderStatus.Pending;
        //     OrderDateTime = DateTime.Now;
        // }

        public Order()
        {
            Products = new List<Product>();
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

        // public bool • A quantidade deve ser menor ou igual a quantidade de estoque;
        // • Ao realizar pedido a baixa na quantidade de estoque deve ser feita;
        // {
        //     throw new NotImplementedException();
        // }

        // public double UseFidelityDiscount()
        // {
        //     throw new NotImplementedException();
        // }

        // Um pedido finalizado não pode ser excluído ou ter seus status alterado;

    }
}
