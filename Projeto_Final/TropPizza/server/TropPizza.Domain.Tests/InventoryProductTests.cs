using System;
using NUnit.Framework;
using TropPizza.Domain.Exceptions.ProductExceptions;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Domain.Tests
{
    public class InventoryProductTests
    {
        private InventoryProduct _inventoryProduct;

        [SetUp]
        public void Setup()
        {
            _inventoryProduct = new InventoryProduct();
        }

        [Test]
        public void Constructor()
        {
            // arrange

            // act
            InventoryProduct inventoryProduct = new InventoryProduct();

            // assert
            Assert.True(inventoryProduct.IsActive);
            Assert.AreEqual(0, inventoryProduct.Quantity);
        }

        [Test]
        public void AddToInventory_Add1From0_Returns1()
        {
            // arrange
            _inventoryProduct.Quantity = 0;
            int quantityToAdd = 1;

            // act
            _inventoryProduct.AddToInventory(quantityToAdd);

            // assert
            Assert.AreEqual(1, _inventoryProduct.Quantity);
        }

        [Test]
        public void RemoveFromInventory_Remove1From1_Returns0()
        {
            // arrange
            _inventoryProduct.Quantity = 1;
            int quantityToRemove = 1;

            // act
            _inventoryProduct.RemoveFromInventory(quantityToRemove);

            // assert
            Assert.AreEqual(0, _inventoryProduct.Quantity);
        }

        [Test]
        public void RemoveFromInventory_Remove1From0_ThrowsException()
        {
            // arrange
            _inventoryProduct.Quantity = 0;
            int quantityToRemove = 1;


            // act
            InsufficientQuantity ex = Assert.Throws<InsufficientQuantity>(() => _inventoryProduct.RemoveFromInventory(quantityToRemove));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O produto não possui a quantidade desejada em estoque!"));
        }

        [Test]
        public void CheckVisibility_ActiveInventoryProductAndQuantityHigherThanZero_ReturnsTrue()
        {
            // arrange
            _inventoryProduct.IsActive = true;
            _inventoryProduct.Quantity = 1;

            // act

            // assert
            Assert.True(_inventoryProduct.IsVisible);
        }

        [Test]
        public void CheckVisibility_InactiveInventoryProductAndQuantityHigherThanZero_ReturnsFalse()
        {
            // arrange
            _inventoryProduct.IsActive = false;
            _inventoryProduct.Quantity = 1;

            // act

            // assert
            Assert.False(_inventoryProduct.IsVisible);
        }

        [Test]
        public void CheckVisibility_ActiveInventoryProductAndQuantityZero_ReturnsFalse()
        {
            // arrange
            _inventoryProduct.IsActive = true;
            _inventoryProduct.Quantity = 0;

            // act

            // assert
            Assert.False(_inventoryProduct.IsVisible);
        }

        [Test]
        public void CheckVisibility_InactiveInventoryProductAndQuantityZero_ReturnsFalse()
        {
            // arrange
            _inventoryProduct.IsActive = false;
            _inventoryProduct.Quantity = 0;

            // act

            // assert
            Assert.False(_inventoryProduct.IsVisible);
        }

        [Test]
        public void Validate_AllValid_ReturnsTrue()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            bool result = _inventoryProduct.Validate();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_NullName_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = null;
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidName ex = Assert.Throws<InvalidName>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O nome não pode ser vazio!"));
        }

        [Test]
        public void Validate_EmptyName_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidName ex = Assert.Throws<InvalidName>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O nome não pode ser vazio!"));
        }

        [Test]
        public void Validate_DescriptionWithLessThan3Characters_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "A";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidDescription ex = Assert.Throws<InvalidDescription>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A descrição não pode ser vazia!"));
        }

        [Test]
        public void Validate_UnitPriceZero_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidUnitPrice ex = Assert.Throws<InvalidUnitPrice>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O preço unitário deve ser maior que zero!"));
        }

        [Test]
        public void Validate_NegativeUnitPrice_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = -0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidUnitPrice ex = Assert.Throws<InvalidUnitPrice>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O preço unitário deve ser maior que zero!"));
        }

        [Test]
        public void Validate_PastExpirationDate_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(-1);
            _inventoryProduct.Quantity = 0;

            // act
            InvalidExpirationDate ex = Assert.Throws<InvalidExpirationDate>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data de validade deve ser maior que a data atual!"));
        }

        [Test]
        public void Validate_NegativeQuantity_ThrowsException()
        {
            // arrange
            _inventoryProduct.Name = "A";
            _inventoryProduct.Description = "AAA";
            _inventoryProduct.UnitPrice = 0.1;
            _inventoryProduct.ExpirationDate = DateTime.Now.AddDays(1);
            _inventoryProduct.Quantity = -1;

            // act
            InvalidQuantity ex = Assert.Throws<InvalidQuantity>(() => _inventoryProduct.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A quantidade deve ser maior ou igual a zero!"));
        }
    }
}