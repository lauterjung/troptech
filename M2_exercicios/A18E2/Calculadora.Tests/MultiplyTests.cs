namespace Calculadora.Tests
{
    public class MultiplyTests
    {
        [Test]
        public void Multiplicar_2and4_Returns8()
        {
            // arrange act
            double result = Operacoes.Multiplicar(2, 4);

            // assert
            Assert.AreEqual(result, 8);
        }
        [Test]
        public void Multiplicar_0and3_Returns0()
        {
            // arrange act
            double result = Operacoes.Multiplicar(0, 3);

            // assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void Multiplicar_7and0_Returns0()
        {
            // arrange act
            double result = Operacoes.Multiplicar(7, 0);

            // assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void Multiplicar_Neg7and2_ReturnsNeg14()
        {
            // arrange act
            double result = Operacoes.Multiplicar(-7, 2);

            // assert
            Assert.AreEqual(result, -14);
        }
        [Test]
        public void Multiplicar_Neg7andNeg2_Returns14()
        {
            // arrange act
            double result = Operacoes.Multiplicar(-7, -2);

            // assert
            Assert.AreEqual(result, 14);
        }
        [Test]
        public void Multiplicar_7d37and2d02_Returns14d89()
        {
            // arrange act
            double result = Operacoes.Multiplicar(7.37, 2.02);

            // assert
            Assert.AreEqual(result, 14.89);
        }
    }
}
