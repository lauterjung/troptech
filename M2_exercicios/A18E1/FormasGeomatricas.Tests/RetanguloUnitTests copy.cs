using System;
using InterfacesExerc1;
using NUnit.Framework;

namespace FormasGeomatricas.Tests
{
    public class RetanguloUnitTests
    {

        [Test]
        public void Constructor_NegativeBaseInput_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Retangulo(-7, 5));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar retângulo com base negativa."));
        }
        [Test]
        public void Constructor_BaseInputZero_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Retangulo(0, 5));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar retângulo com base zerada."));
        }
        [Test]
        public void Constructor_NegativeHeightInput_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Retangulo(7, -5));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar retângulo com altura negativa."));
        }
        [Test]
        public void Constructor_HeightInputZero_ReturnErrorMessage()
        {
            // arrange action
            Exception ex = Assert.Throws<Exception>(() => new Retangulo(5, 0));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível criar retângulo com altura zerada."));
        }

        [Test]
        public void CalculaArea_Input9and10_Returns90()
        {
            // arrange 
            Retangulo retangulo = new Retangulo(9, 10);

            // action
            double area = retangulo.CalculaArea();

            // assert
            Assert.AreEqual(90, area);
        }
        [Test]
        public void CalculaArea_Input9d7and10d33_Returns100d20()
        {
            // arrange 
            Retangulo retangulo = new Retangulo(9.7, 10.33);

            // action
            double area = retangulo.CalculaArea();

            // assert
            Assert.AreEqual(100.20, area);
        }
    }
}