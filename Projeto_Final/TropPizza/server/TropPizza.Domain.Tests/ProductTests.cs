using System;
using NUnit.Framework;
using TropPizza.Domain.Exceptions.ProductExceptions;
using TropPizza.Domain.Features.Products;


namespace TropPizza.Domain.Tests
{
    public class ProductTests
    {
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product();
        }

        [Test]
        public void Constructor()
        {
            // arrange

            // act
            Product product = new Product();

            // assert
            Assert.True(product.IsActive);
            Assert.AreEqual(0, product.Quantity);
        }

        [Test]
        public void CalculateTotalPrice_ZeroQuantity_ReturnsZero()
        {
            // arrange
            _product.Quantity = 0;
            _product.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(0, _product.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_1QuantityAnd1d5UnitPrice_Returns1d5()
        {
            // arrange
            _product.Quantity = 1;
            _product.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(1.5, _product.TotalPrice);
        }

        [Test]
        public void CalculateTotalPrice_2QuantityAnd1d5UnitPrice_Returns3()
        {
            // arrange
            _product.Quantity = 2;
            _product.UnitPrice = 1.5;

            // act

            // assert
            Assert.AreEqual(3, _product.TotalPrice);
        }

        [Test]
        public void AddToInventory_Add1From0_Returns1()
        {
            // arrange
            _product.Quantity = 0;
            int quantityToAdd = 1;

            // act
            _product.AddToInventory(quantityToAdd);

            // assert
            Assert.AreEqual(1, _product.Quantity);
        }

        [Test]
        public void RemoveFromInventory_Remove1From1_Returns0()
        {
            // arrange
            _product.Quantity = 1;
            int quantityToRemove = 1;

            // act
            _product.RemoveFromInventory(quantityToRemove);

            // assert
            Assert.AreEqual(0, _product.Quantity);
        }

        [Test]
        public void RemoveFromInventory_Remove1From0_ThrowsException()
        {
            // arrange
            _product.Quantity = 0;
            int quantityToRemove = 1;


            // act
            InsufficientQuantity ex = Assert.Throws<InsufficientQuantity>(() => _product.RemoveFromInventory(quantityToRemove));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O produto não possui a quantidade desejada em estoque!"));
        }

        [Test]
        public void CheckVisibility_ActiveProductAndQuantityHigherThanZero_ReturnsTrue()
        {
            // arrange
            _product.IsActive = true;
            _product.Quantity = 1;

            // act

            // assert
            Assert.True(_product.IsVisible);
        }

        [Test]
        public void CheckVisibility_InactiveProductAndQuantityHigherThanZero_ReturnsFalse()
        {
            // arrange
            _product.IsActive = false;
            _product.Quantity = 1;

            // act

            // assert
            Assert.False(_product.IsVisible);
        }

        [Test]
        public void CheckVisibility_ActiveProductAndQuantityZero_ReturnsFalse()
        {
            // arrange
            _product.IsActive = true;
            _product.Quantity = 0;

            // act

            // assert
            Assert.False(_product.IsVisible);
        }

        [Test]
        public void CheckVisibility_InactiveProductAndQuantityZero_ReturnsFalse()
        {
            // arrange
            _product.IsActive = false;
            _product.Quantity = 0;

            // act

            // assert
            Assert.False(_product.IsVisible);
        }

        [Test]
        public void Validate_AllValid_ReturnsTrue()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "AAA";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            bool result = _product.Validate();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_NullName_ThrowsException()
        {
            // arrange
            _product.Name = null;
            _product.Description = "AAA";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            InvalidName ex = Assert.Throws<InvalidName>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O nome não pode ser vazio!"));
        }

        [Test]
        public void Validate_EmptyName_ThrowsException()
        {
            // arrange
            _product.Name = "";
            _product.Description = "AAA";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            InvalidName ex = Assert.Throws<InvalidName>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O nome não pode ser vazio!"));
        }

        [Test]
        public void Validate_DescriptionWithLessThan3Characters_ThrowsException()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "A";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            InvalidDescription ex = Assert.Throws<InvalidDescription>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A descrição não pode ser vazia!"));
        }

        [Test]
        public void Validate_UnitPriceZero_ThrowsException()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "AAA";
            _product.UnitPrice = 0;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            InvalidUnitPrice ex = Assert.Throws<InvalidUnitPrice>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O preço unitário deve ser maior que zero!"));
        }

        [Test]
        public void Validate_NegativeUnitPrice_ThrowsException()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "AAA";
            _product.UnitPrice = -0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = 0;

            // act
            InvalidUnitPrice ex = Assert.Throws<InvalidUnitPrice>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O preço unitário deve ser maior que zero!"));
        }

        [Test]
        public void Validate_PastExpirationDate_ThrowsException()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "AAA";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(-1);
            _product.Quantity = 0;

            // act
            InvalidExpirationDate ex = Assert.Throws<InvalidExpirationDate>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data de validade deve ser maior que a data atual!"));
        }

        [Test]
        public void Validate_NegativeQuantity_ThrowsException()
        {
            // arrange
            _product.Name = "A";
            _product.Description = "AAA";
            _product.UnitPrice = 0.1;
            _product.ExpirationDate = DateTime.Now.AddDays(1);
            _product.Quantity = -1;

            // act
            InvalidQuantity ex = Assert.Throws<InvalidQuantity>(() => _product.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A quantidade deve ser maior ou igual a zero!"));
        }
    }
}