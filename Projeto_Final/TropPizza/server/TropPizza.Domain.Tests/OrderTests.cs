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
            CollectionAssert.IsEmpty(order.CartProducts);
            Assert.AreEqual("Pendente", order.Status);
            Assert.AreEqual(OrderStatus.Pending, order.StatusEnum);
        }

        [Test]
        public void CalculateTotalPrice_NoProducts_Returns0()
        {
            // arrange
            _order.CartProducts = new List<CartProduct>();

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
            CartProduct product1 = new CartProduct();
            product1.Quantity = 2;
            product1.UnitPrice = 1.5;

            _order.CartProducts = new List<CartProduct>() { product1 };

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
            CartProduct product1 = new CartProduct();
            product1.Quantity = 2;
            product1.UnitPrice = 1.5;
            CartProduct product2 = new CartProduct();
            product2.Quantity = 3;
            product2.UnitPrice = 2;

            _order.CartProducts = new List<CartProduct>() { product1, product2 };

            // act
            double result = _order.CalculateTotalPrice();

            // assert
            Assert.AreEqual(9, result);
            Assert.AreEqual(9, _order.TotalPrice);
        }

        [Test]
        public void Status_Enum0_CorrectString()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)0;
            string result = "Pendente";
            
            // act
            // assert
            Assert.AreEqual(result, _order.Status);
        }

        [Test]
        public void Status_Enum1_CorrectString()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)1;
            string result = "Em preparo";

            // act
            // assert
            Assert.AreEqual(result, _order.Status);
        }

        [Test]
        public void Status_Enum2_CorrectString()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)2;
            string result = "Saiu para entrega";

            // act
            // assert
            Assert.AreEqual(result, _order.Status);
        }

        [Test]
        public void Status_Enum3_CorrectString()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)3;
            string result = "Entregue";

            // act
            // assert
            Assert.AreEqual(result, _order.Status);
        }

        [Test]
        public void CanBeUpdated_FinishedOrderStatus_ThrowsException()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)3;

            // act
            InvalidDeletion ex = Assert.Throws<InvalidDeletion>(() => _order.CanBeUpdated());

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível deletar pedidos finalizados!"));
        }

        [Test]
        public void CanBeUpdated_PendingOrderStatus_ReturnsTrue()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)0;

            // act
            bool result = _order.CanBeUpdated();

            // assert
            Assert.True(result);
        }

        [Test]
        public void CanBeUpdated_PreparationOrderStatus_ReturnsTrue()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)1;

            // act
            bool result = _order.CanBeUpdated();

            // assert
            Assert.True(result);
        }

        [Test]
        public void CanBeUpdated_DeliveryOrderStatus_ReturnsTrue()
        {
            // arrange
            _order.StatusEnum = (OrderStatus)2;

            // act
            bool result = _order.CanBeUpdated();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_AllValid_ReturnsTrue()
        {
            // arrange
            CartProduct product = new CartProduct();

            _order.CartProducts = new List<CartProduct>() { product };
            _order.StatusEnum = (OrderStatus)0;

            // act
            bool result = _order.Validate();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_InvalidStatus_ThrowsException()
        {
            // arrange
            CartProduct product = new CartProduct();

            _order.CartProducts = new List<CartProduct>() { product };
            _order.StatusEnum = (OrderStatus)99;

            // act
            InvalidStatus ex = Assert.Throws<InvalidStatus>(() => _order.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O status do pedido é inválido!"));
        }

        [Test]
        public void Validate_NoProducts_ThrowsException()
        {
            // arrange
            _order.CartProducts = new List<CartProduct>();
            _order.StatusEnum = (OrderStatus)0;

            // act
            InvalidProducts ex = Assert.Throws<InvalidProducts>(() => _order.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O pedido deve conter pelo menos um produto!"));
        }
    }
}