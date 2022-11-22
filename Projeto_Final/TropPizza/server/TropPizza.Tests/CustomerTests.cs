using System;
using NUnit.Framework;
using TropPizza.Domain.Features.Customers;

namespace TropPizza.Tests
{
    public class CustomerTests
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void CheckFidelityDiscount_FidelityPointsHigherThan10_ReturnsTrue()
        {
            // arrange
            _customer.FidelityPoints = 11;

            // act

            // assert
            Assert.True(_customer.HasFidelityDiscount);
        }

        [Test]
        public void CheckFidelityDiscount_FidelityPointsEqualTo10_ReturnsTrue()
        {
            // arrange
            _customer.FidelityPoints = 10;

            // act

            // assert
            Assert.True(_customer.HasFidelityDiscount);
        }

        [Test]
        public void CheckFidelityDiscount_FidelityPointsLowerThan10_ReturnsFalse()
        {
            // arrange
            _customer.FidelityPoints = 0;

            // act

            // assert
            Assert.False(_customer.HasFidelityDiscount);
        }
        
        // [Test]
        // public void CheckValidBirthDate_ValidBirthDate_ReturnsTrue()
        // {
        //     // arrange
        //     _customer.BirthDate = DateTime.Now.AddDays(-1);

        //     // act
        //     bool result = _customer.CheckValidBirthDate();

        //     // assert
        //     Assert.True(result);
        // }

        // [Test]
        // public void CheckValidBirthDate_InvalidBirthDate_ReturnsFalse()
        // {
        //     // arrange
        //     _customer.BirthDate = DateTime.Now;

        //     // act
        //     bool result = _customer.CheckValidBirthDate();

        //     // assert
        //     Assert.False(result);
        // }
    }
}