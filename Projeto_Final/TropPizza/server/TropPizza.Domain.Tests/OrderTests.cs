using System;
using System.Collections.Generic;
using NUnit.Framework;
using TropPizza.Domain.Exceptions.OrderExceptions;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Domain.Tests
{
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _order = new Order();
        }

        [Test]
        public void Constructor()
        {
            // arrange
 
            // act
            Order order = new Order();

            // assert
            CollectionAssert.IsEmpty(order.Products);
            Assert.AreEqual(OrderStatus.Pending, order.Status);
        }

        [Test]
        public void CalculateTotalPrice_NoProducts_Returns0()
        {
            // arrange
            _order.Products = new List<Product>();

            // act
            double result = _order.CalculateTotalPrice();

            // assert
            Assert.AreEqual(0, result);
            Assert.AreEqual(0, _order.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_OneProduct_Quantity2Price1d5_Returns3()
        {
            // arrange
            Product product1 = new Product();
            product1.Quantity = 2;
            product1.UnitPrice = 1.5;

            _order.Products = new List<Product>() { product1 };

            // act
            double result = _order.CalculateTotalPrice();

            // assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(3, _order.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_TwoProducts_Quantity2Price1d5AndQuantity3Price2_Returns9()
        {
            // arrange
            Product product1 = new Product();
            product1.Quantity = 2;
            product1.UnitPrice = 1.5;
            Product product2 = new Product();
            product2.Quantity = 3;
            product2.UnitPrice = 2;

            _order.Products = new List<Product>() { product1, product2 };

            // act
            double result = _order.CalculateTotalPrice();

            // assert
            Assert.AreEqual(9, result);
            Assert.AreEqual(9, _order.TotalPrice);
        }

        [Test]
        public void Validate_AllValid_ReturnsTrue()
        {
            // arrange
            Product product = new Product();

            _order.Products = new List<Product>() { product };
            _order.Status = (OrderStatus)0;

            // act
            bool result = _order.Validate();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_InvalidStatus_ThrowsException()
        {
            // arrange
            Product product = new Product();

            _order.Products = new List<Product>() { product };
            _order.Status = (OrderStatus)99;

            // act
            InvalidStatus ex = Assert.Throws<InvalidStatus>(() => _order.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O status do pedido é inválido!"));
        }

        [Test]
        public void Validate_NoProducts_ThrowsException()
        {
            // arrange
            _order.Products = new List<Product>();
            _order.Status = (OrderStatus)0;

            // act
            InvalidProducts ex = Assert.Throws<InvalidProducts>(() => _order.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O pedido deve conter pelo menos um produto!"));
        }
    }
}