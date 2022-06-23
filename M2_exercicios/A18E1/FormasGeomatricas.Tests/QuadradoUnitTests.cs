using System;
using InterfacesExerc1;
using NUnit.Framework;

namespace FormasGeomatricas.Tests
{
    public class QuadradoUnitTests
    {
        [Test]
        public void Constructor_NegativeInput_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Quadrado(-4));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar quadrado com lado negativo."));
        }
        [Test]
        public void Constructor_InputZero_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Quadrado(0));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar quadrado com lado igual a zero."));
        }
        [Test]
        public void CalculaArea_Input5_Returns25()
        {
            // arrange 
            Quadrado quadrado = new Quadrado(5);

            // action
            double area = quadrado.CalculaArea();

            // assert
            Assert.AreEqual(25, area);
        }
        [Test]
        public void CalculaArea_Input8d47_Returns71d74()
        {
            // arrange 
            Quadrado quadrado = new Quadrado(8.47);

            // action
            double area = quadrado.CalculaArea();

            // assert
            Assert.AreEqual(71.74, area);
        }
    }
}