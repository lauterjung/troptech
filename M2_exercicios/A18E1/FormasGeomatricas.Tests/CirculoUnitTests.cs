using System;
using InterfacesExerc1;
using NUnit.Framework;

namespace FormasGeomatricas.Tests
{
    public class CirculoUnitTests
    {
        public void Constructor_NegativeInput_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Circulo(-4));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar círculo com raio negativo."));
        }
        public void Constructor_InputZero_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Circulo(-4));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar círculo com raio zerado."));
        }

        [Test]
        public void CalculaArea_Input5_Returns78d54()
        {
            // arrange 
            Circulo circulo = new Circulo(5);

            // action
            double area = circulo.CalculaArea();

            // assert
            Assert.AreEqual(78.54, area);
        }
        [Test]
        public void CalculaArea_Input5d33_Returns89d25()
        {
            // arrange 
            Circulo circulo = new Circulo(5.33);

            // action
            double area = circulo.CalculaArea();

            // assert
            Assert.AreEqual(89.25, area);
        }
    }
}