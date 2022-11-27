using System;
using NUnit.Framework;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Exceptions.CustomerExceptions;

namespace TropPizza.Domain.Tests
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
        public void Constructor()
        {
            // arrange

            // act
            Customer customer = new Customer();

            // assert
            Assert.AreEqual(0, customer.FidelityPoints);
        }

        [Test]
        public void ApplyFidelityPoints_TotalPrice1_Adds2()
        {
            // arrange
            double totalPrice = 1;

            // act
            _customer.ApplyFidelityPoints(totalPrice);

            // assert
            Assert.AreEqual(2, _customer.FidelityPoints);
        }

        [Test]
        public void Validate_AllValid_ReturnsTrue()
        {
            // arrange
            _customer.Cpf = "00000000000";
            _customer.FullName = "AAA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            bool result = _customer.Validate();

            // assert
            Assert.True(result);
        }

        [Test]
        public void Validate_CpfWithCharacters_ThrowsException()
        {
            // arrange
            _customer.Cpf = "AAAAAAAAAAA";
            _customer.FullName = "AAA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidCpf ex = Assert.Throws<InvalidCpf>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O CPF precisa conter 11 dígitos numéricos!"));
        }

        [Test]
        public void Validate_CpfWithLessThan11Digits_ThrowsException()
        {
            // arrange
            _customer.Cpf = "0000000000";
            _customer.FullName = "AAA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidCpf ex = Assert.Throws<InvalidCpf>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O CPF precisa conter 11 dígitos numéricos!"));
        }

        [Test]
        public void Validate_CpfWithMoreThan11Digits_ThrowsException()
        {
            // arrange
            _customer.Cpf = "000000000000";
            _customer.FullName = "AAA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidCpf ex = Assert.Throws<InvalidCpf>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O CPF precisa conter 11 dígitos numéricos!"));
        }

        [Test]
        public void Validate_FullNameWithLessThan3Digits_ThrowsException()
        {
            // arrange
            _customer.Cpf = "00000000000";
            _customer.FullName = "AA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidFullName ex = Assert.Throws<InvalidFullName>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O nome completo precisa ter pelo menos 3 caracteres!"));
        }

        [Test]
        public void Validate_NullAdress_ThrowsException()
        {
            // arrange
            _customer.Cpf = "00000000000";
            _customer.FullName = "AAA";
            _customer.Address = null;
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidAddress ex = Assert.Throws<InvalidAddress>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O endereço não pode ser vazio!"));
        }

        [Test]
        public void Validate_EmptyAdress_ThrowsException()
        {
            // arrange
            _customer.Cpf = "00000000000";
            _customer.FullName = "AAA";
            _customer.Address = "";
            _customer.BirthDate = DateTime.Now.AddDays(-1);

            // act
            InvalidAddress ex = Assert.Throws<InvalidAddress>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("O endereço não pode ser vazio!"));
        }

        [Test]
        public void Validate_FutureBirthDate_ThrowsException()
        {
            // arrange
            _customer.Cpf = "00000000000";
            _customer.FullName = "AAA";
            _customer.Address = "A";
            _customer.BirthDate = DateTime.Now.AddDays(1);

            // act
            InvalidBirthDate ex = Assert.Throws<InvalidBirthDate>(() => _customer.Validate());

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data de nascimento precisa ser inferior ao dia de hoje!"));
        }
    }
}