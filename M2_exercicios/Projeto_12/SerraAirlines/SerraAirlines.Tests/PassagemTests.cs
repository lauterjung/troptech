using NUnit.Framework;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Exceptions;
using System;

namespace SerraAirlines.Tests
{
    public class PassagemTests
    {
        private Passagem _passagem;

        [SetUp]
        public void Setup()
        {
            _passagem = new Passagem();
        }

        [Test]
        public void VerificarDataValida_InserindoDataValida_RetornaTrue()
        {
            // arrange
            _passagem.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _passagem.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            bool resultado = _passagem.VerificarDataValida();

            // assert
            Assert.True(resultado);
        }

        [Test]
        public void VerificarDataValida_InserindoDataInvalida_RetornaFalse()
        {
            // arrange
            _passagem.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");
            _passagem.DataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");

            // act
            bool resultado = _passagem.VerificarDataValida();

            // assert
            Assert.False(resultado);
        }

        [Test]
        public void Construtor_InserindoDataValida_RetornaObjeto()
        {
            // arrange
            string origem = "A";
            string destino = "B";
            double valor = 1;
            DateTime dataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            DateTime dataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            Passagem passagem = new Passagem(origem, destino, valor, dataHoraOrigem, dataHoraDestino);

            // assert
            Assert.AreEqual(passagem.Origem, origem);
            Assert.AreEqual(passagem.Destino, destino);
            Assert.AreEqual(passagem.Valor, valor);
            Assert.AreEqual(passagem.DataHoraOrigem, dataHoraOrigem);
            Assert.AreEqual(passagem.DataHoraDestino, dataHoraDestino);
        }

        [Test]
        public void Construtor_InserindoDataInvalida_JogaExcecao()
        {
            // arrange
            string origem = "A";
            string destino = "B";
            double valor = 1;
            DateTime dataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");
            DateTime dataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");

            // act
            DataHoraOrigemDestinoInvalida ex = Assert.Throws<DataHoraOrigemDestinoInvalida>(() => new Passagem(origem, destino, valor, dataHoraOrigem, dataHoraDestino));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data/hora de origem não pode ser inferior a de destino!"));
        }

        [Test]
        public void Construtor_InserindoValorValido_RetornaObjeto()
        {
            // arrange
            string origem = "A";
            string destino = "B";
            double valor = 1;
            DateTime dataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            DateTime dataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            Passagem passagem = new Passagem(origem, destino, valor, dataHoraOrigem, dataHoraDestino);

            // assert
            Assert.AreEqual(passagem.Origem, origem);
            Assert.AreEqual(passagem.Destino, destino);
            Assert.AreEqual(passagem.Valor, valor);
            Assert.AreEqual(passagem.DataHoraOrigem, dataHoraOrigem);
            Assert.AreEqual(passagem.DataHoraDestino, dataHoraDestino);
        }

        [Test]
        public void Construtor_InserindoValorZero_JogaExcecao()
        {
            // arrange
            string origem = "A";
            string destino = "B";
            double valor = 0;
            DateTime dataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            DateTime dataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            ValorInvalido ex = Assert.Throws<ValorInvalido>(() => new Passagem(origem, destino, valor, dataHoraOrigem, dataHoraDestino));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O valor da passagem deve ser maior que zero!"));
        }

        [Test]
        public void Construtor_InserindoValorNegativo_JogaExcecao()
        {
            // arrange
            string origem = "A";
            string destino = "B";
            double valor = -1;
            DateTime dataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            DateTime dataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            ValorInvalido ex = Assert.Throws<ValorInvalido>(() => new Passagem(origem, destino, valor, dataHoraOrigem, dataHoraDestino));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O valor da passagem deve ser maior que zero!"));
        }
    }
}