namespace Calculadora.Tests
{
    public class DivideTests
    {
        [Test]
        public void Divide_10and2_Returns5()
        {
            // arrange act
            double result = Operacoes.Dividir(10, 2);

            // assert
            Assert.AreEqual(result, 5);
        }
        [Test]
        public void Divide_7and2_Returns3d5()
        {
            // arrange act
            double result = Operacoes.Dividir(7, 2);

            // assert
            Assert.AreEqual(result, 3.5);
        }
        [Test]
        public void Divide_8and0_ShowsError()
        {
            // arrange act
            Exception ex = Assert.Throws<Exception>(() => Operacoes.Dividir(8, 0));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Não é possível dividir por zero"));
        }
        [Test]
        public void Divide_0and8_Returns0()
        {
            // arrange act
            double result = Operacoes.Dividir(0, 8);

            // assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void Divide_14d98and3_Returns4d99()
        {
            // arrange act
            double result = Operacoes.Dividir(14.98, 3);

            // assert
            Assert.AreEqual(result, 4.99);
        }
    }
}
