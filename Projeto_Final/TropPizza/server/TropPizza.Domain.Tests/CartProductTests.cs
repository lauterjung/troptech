using NUnit.Framework;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Domain.Tests
{
    public class CartProductTests
    {
        private CartProduct _cartProduct;

        [SetUp]
        public void Setup()
        {
            _cartProduct = new CartProduct();
        }

        [Test]
        public void CalculateTotalPrice_ZeroQuantity_ReturnsZero()
        {
            // arrange
            _cartProduct.Quantity = 0;
            _cartProduct.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(0, _cartProduct.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_1QuantityAnd1d5UnitPrice_Returns1d5()
        {
            // arrange
            _cartProduct.Quantity = 1;
            _cartProduct.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(1.5, _cartProduct.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_2QuantityAnd1d5UnitPrice_Returns3()
        {
            // arrange
            _cartProduct.Quantity = 2;
            _cartProduct.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(3, _cartProduct.TotalPrice);
        }
    }
}