using NUnit.Framework;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Enums;
using SerraAirlines.Domain.Exceptions;
using System;

namespace SerraAirlines.Tests
{
    public class ClienteTests
    {
        private Cliente _cliente;
        private Passagem _passagemIda;
        private Passagem _passagemVolta;
        private Viagem _viagem;

        [SetUp]
        public void Setup()
        {
            _cliente = new Cliente();
            _passagemIda = new Passagem();
            _passagemVolta = new Passagem();
            _viagem = new Viagem();
            _viagem.CodigoReserva = "AAAAAA";
        }

        [Test]
        public void MarcarViagem_ViagemCodigoInvalido_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = false;

            _viagem.CodigoReserva = "AAA111";
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = null;

            // act
            CodigoInvalido ex = Assert.Throws<CodigoInvalido>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O código é inválido, deve possuir 6 letras!"));
        }
        [Test]
        public void MarcarViagem_ViagensNaoVinculadas_RetornaViagemComPassagensVinculadas()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = false;
            _passagemVolta.Id = 2;
            _passagemVolta.EstaVinculada = false;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = _passagemVolta;

            // act
            Viagem resultado = _cliente.MarcarViagem(_viagem);

            // assert
            Assert.True(resultado.PassagemIda.EstaVinculada);
            Assert.True(resultado.PassagemVolta.EstaVinculada);
        }

        [Test]
        public void MarcarViagem_ViagensIguais_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = false;
            _passagemVolta.Id = 1;
            _passagemVolta.EstaVinculada = false;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = _passagemVolta;

            // act
            PassagensRepetidas ex = Assert.Throws<PassagensRepetidas>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A passagem de ida é igual a passagem de volta!"));
        }

        [Test]
        public void MarcarViagem_ViagemIdaJaVinculada_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = true;
            _passagemVolta.Id = 2;
            _passagemVolta.EstaVinculada = false;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = _passagemVolta;

            // act
            PassagemJaVinculada ex = Assert.Throws<PassagemJaVinculada>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A passagem já está vinculada!"));
        }

        [Test]
        public void MarcarViagem_ViagemVoltaJaVinculada_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = false;
            _passagemVolta.Id = 2;
            _passagemVolta.EstaVinculada = true;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = _passagemVolta;

            // act
            PassagemJaVinculada ex = Assert.Throws<PassagemJaVinculada>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A passagem já está vinculada!"));
        }

        [Test]
        public void MarcarViagem_ViagemIdaEVoltaJaVinculada_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = true;
            _passagemVolta.Id = 2;
            _passagemVolta.EstaVinculada = true;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = _passagemVolta;

            // act
            PassagemJaVinculada ex = Assert.Throws<PassagemJaVinculada>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A passagem já está vinculada!"));
        }

        [Test]
        public void MarcarViagem_ViagemIdaVinculadaEViagemVoltaNull_DisparaExcecao()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = true;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = null;

            // act
            PassagemJaVinculada ex = Assert.Throws<PassagemJaVinculada>(() => _cliente.MarcarViagem(_viagem));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A passagem já está vinculada!"));
        }

        [Test]
        public void MarcarViagem_ViagemIdaDesvinculadaEViagemVoltaNull_RetornaViagemComPassagemVinculada()
        {
            // arrange
            _passagemIda.Id = 1;
            _passagemIda.EstaVinculada = false;
            _viagem.PassagemIda = _passagemIda;
            _viagem.PassagemVolta = null;

            // act
            Viagem resultado = _cliente.MarcarViagem(_viagem);

            // assert
            Assert.True(resultado.PassagemIda.EstaVinculada);
            Assert.IsNull(resultado.PassagemVolta);
        }
    }
}
