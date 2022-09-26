using NUnit.Framework;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Enums;
using SerraAirlines.Domain.Exceptions;
using System;

namespace SerraAirlines.Tests
{
    public class ViagemTests
    {
        private Viagem _viagem;

        [SetUp]
        public void Setup()
        {
            string _codigoReserva = "AAAAAA";
            DateTime _dataHoraCompra = Convert.ToDateTime("2000-01-01 00:00:00");
            Cliente _cliente = new Cliente();
            Passagem _passagemIda = new Passagem();

            _viagem = new Viagem(_codigoReserva, _dataHoraCompra, _cliente, _passagemIda, null);
        }

        [Test]
        public void VerificarCodigoValido_InserindoCodigoValido_RetornaTrue()
        {
            // arrange
            _viagem.CodigoReserva = "AAAAAA";

            // act
            bool resultado = _viagem.VerificarCodigoValido();

            // assert
            Assert.True(resultado);
        }


        [Test]
        public void VerificarCodigoValido_InserindoCodigoCom7Letras_RetornaFalse()
        {
            // arrange
            _viagem.CodigoReserva = "ABCDEFG";

            // act
            bool resultado = _viagem.VerificarCodigoValido();

            // assert
            Assert.False(resultado);
        }

        [Test]
        public void VerificarCodigoValido_InserindoCodigoComNumeros_RetornaFalse()
        {
            // arrange
            _viagem.CodigoReserva = "AAA111";

            // act
            bool resultado = _viagem.VerificarCodigoValido();

            // assert
            Assert.False(resultado);
        }

        [Test]
        public void VerificarDataValida_InserindoDataValida_RetornaTrue()
        {
            // arrange
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            bool resultado = _viagem.VerificarDataValida();

            // assert
            Assert.True(resultado);
        }

        [Test]
        public void VerificarDataValida_InserindoDataInvalida_RetornaTrue()
        {
            // arrange
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");

            // act
            bool resultado = _viagem.VerificarDataValida();

            // assert
            Assert.False(resultado);
        }

        [Test]
        public void VerificarTipoViagem_ViagemSomenteIda_RetornaTipoIda()
        {
            // arrange

            // act
            TipoViagem resultado = _viagem.VerificarTipoViagem();

            // assert
            Assert.AreEqual(resultado, TipoViagem.Ida);
        }

        [Test]
        public void VerificarTipoViagem_ViagemIdaEVolta_RetornaTipoIdaEVolta()
        {
            // arrange
            _viagem.PassagemVolta = new Passagem();

            // act
            TipoViagem resultado = _viagem.VerificarTipoViagem();

            // assert
            Assert.AreEqual(resultado, TipoViagem.Ida_e_volta);
        }

        [Test]
        public void Construtor_InserindoCodigoValido_RetornaObjeto()
        {
            // arrange
            string codigoReserva = "AAAAAA";
            DateTime dataHoraCompra = Convert.ToDateTime("2000-01-01 00:00:00");
            Cliente cliente = new Cliente();
            Passagem passagemIda = new Passagem();
            Passagem passagemVolta = new Passagem();
            passagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");
            passagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            Viagem viagem = new Viagem(codigoReserva, dataHoraCompra, cliente, passagemIda, passagemVolta);

            // assert
            Assert.AreEqual(viagem.CodigoReserva, codigoReserva);
            Assert.AreEqual(viagem.DataHoraCompra, dataHoraCompra);
            Assert.AreEqual(viagem.Cliente, cliente);
            Assert.AreEqual(viagem.PassagemIda, passagemIda);
            Assert.AreEqual(viagem.PassagemVolta, passagemVolta);
        }

        [Test]
        public void Construtor_InserindoCodigoInvalido_DisparaExcecao()
        {
            // arrange
            string codigoReserva = "AAA111";
            DateTime dataHoraCompra = Convert.ToDateTime("2000-01-01 00:00:00");
            Cliente cliente = new Cliente();
            Passagem passagemIda = new Passagem();
            Passagem passagemVolta = new Passagem();
            passagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");
            passagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            CodigoInvalido ex = Assert.Throws<CodigoInvalido>(() => new Viagem(codigoReserva, dataHoraCompra, cliente, passagemIda, passagemVolta));

            // assert
            Assert.That(ex.Message, Is.EqualTo("O código é inválido, deve possuir 6 letras!"));
        }

        [Test]
        public void Construtor_InserindoDataValida_RetornaObjeto()
        {
            // arrange
            string codigoReserva = "AAAAAA";
            DateTime dataHoraCompra = Convert.ToDateTime("2000-01-01 00:00:00");
            Cliente cliente = new Cliente();
            Passagem passagemIda = new Passagem();
            Passagem passagemVolta = new Passagem();
            passagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-01 00:00:00");
            passagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            Viagem viagem = new Viagem(codigoReserva, dataHoraCompra, cliente, passagemIda, passagemVolta);

            // assert
            Assert.AreEqual(viagem.CodigoReserva, codigoReserva);
            Assert.AreEqual(viagem.DataHoraCompra, dataHoraCompra);
            Assert.AreEqual(viagem.Cliente, cliente);
            Assert.AreEqual(viagem.PassagemIda, passagemIda);
            Assert.AreEqual(viagem.PassagemVolta, passagemVolta);
        }

        [Test]
        public void Construtor_InserindoDataInvalida_DisparaExcecao()
        {
            // arrange
            string codigoReserva = "AAAAAA";
            DateTime dataHoraCompra = Convert.ToDateTime("2000-01-01 00:00:00");
            Cliente cliente = new Cliente();
            Passagem passagemIda = new Passagem();
            Passagem passagemVolta = new Passagem();
            passagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            passagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");

            // act
            DataHoraIdaVoltaInvalida ex = Assert.Throws<DataHoraIdaVoltaInvalida>(() => new Viagem(codigoReserva, dataHoraCompra, cliente, passagemIda, passagemVolta));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data/hora de destino da passagem de ida não pode ser inferior a data/hora de origem da passagem de volta!"));
        }

        [Test]
        public void CalcularValorTotal_PassagemIdaValor1_Retorna1()
        {
            // arrange
            _viagem.PassagemIda.Valor = 1;
            _viagem.PassagemVolta = null;

            // act
            double resultado = (double)_viagem.CalcularValorTotal();

            // assert
            Assert.AreEqual(1, resultado);
            Assert.AreEqual(1, _viagem.ValorTotal);
        }

        [Test]
        public void CalcularValorTotal_PassagemIdaValor1_E_PassagemVoltaValor1_Retorna2()
        {
            // arrange
            _viagem.PassagemIda.Valor = 1;
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.Valor = 1;

            // act
            double resultado = (double)_viagem.CalcularValorTotal();

            // assert
            Assert.AreEqual(2, resultado);
            Assert.AreEqual(2, _viagem.ValorTotal);
        }

        [Test]
        public void ResumirViagem_SomenteViagemIda_RetornaStringIda()
        {
            // arrange
            _viagem.PassagemIda.Origem = "A";
            _viagem.PassagemIda.Destino = "B";
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemVolta = null;

            // act
            string resultado = _viagem.ResumirViagem();

            // assert
            Assert.AreEqual("Seu voo de A a B será dia 01/01/2000 as 00:00", resultado);
            Assert.AreEqual("Seu voo de A a B será dia 01/01/2000 as 00:00", _viagem.ResumoViagem);
        }

        [Test]
        public void ResumirViagem_ViagemIdaEVolta_RetornaStringCompleta()
        {
            // arrange
            _viagem.PassagemIda.Origem = "A";
            _viagem.PassagemIda.Destino = "B";
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.Origem = "C";
            _viagem.PassagemVolta.Destino = "D";
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-02 00:00:00");

            // act
            string resultado = _viagem.ResumirViagem();

            // assert
            Assert.AreEqual("Seu voo de ida de A a B será dia 01/01/2000 as 00:00 e seu voo de volta de C a D será dia 02/01/2000 as 00:00", resultado);
            Assert.AreEqual("Seu voo de ida de A a B será dia 01/01/2000 as 00:00 e seu voo de volta de C a D será dia 02/01/2000 as 00:00", _viagem.ResumoViagem);
        }

        [Test]
        public void RemarcarViagem_SomentePassagemIda_E_DatasValidas_RetornaViagemRemarcada()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = null;

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            viagemParaRemarcar.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");
            viagemParaRemarcar.PassagemVolta = null;

            // act
            Viagem viagemRemarcada = _viagem.RemarcarViagem(viagemParaRemarcar);

            // assert
            Assert.AreEqual(Convert.ToDateTime("2000-01-03 00:00:00"), viagemRemarcada.PassagemIda.DataHoraOrigem);
            Assert.AreEqual(Convert.ToDateTime("2000-01-04 00:00:00"), viagemRemarcada.PassagemIda.DataHoraDestino);
        }

        [Test]
        public void RemarcarViagem_PassagemIdaEVolta_E_DatasValidas_RetornaViagemRemarcada()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            _viagem.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            viagemParaRemarcar.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");
            viagemParaRemarcar.PassagemVolta = new Passagem();
            viagemParaRemarcar.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-05 00:00:00");
            viagemParaRemarcar.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-06 00:00:00");

            // act
            Viagem viagemRemarcada = _viagem.RemarcarViagem(viagemParaRemarcar);

            // assert
            Assert.AreEqual(Convert.ToDateTime("2000-01-03 00:00:00"), viagemRemarcada.PassagemIda.DataHoraOrigem);
            Assert.AreEqual(Convert.ToDateTime("2000-01-04 00:00:00"), viagemRemarcada.PassagemIda.DataHoraDestino);
            Assert.AreEqual(Convert.ToDateTime("2000-01-05 00:00:00"), viagemRemarcada.PassagemVolta.DataHoraOrigem);
            Assert.AreEqual(Convert.ToDateTime("2000-01-06 00:00:00"), viagemRemarcada.PassagemVolta.DataHoraDestino);
        }

        [Test]
        public void RemarcarViagem_SomentePassagemIda_E_DatasPassagensInvalidas_DisparaExcecao()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = null;

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-04 00:00:00");
            viagemParaRemarcar.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-03 00:00:00");
            viagemParaRemarcar.PassagemVolta = null;

            // act
            DataHoraOrigemDestinoInvalida ex = Assert.Throws<DataHoraOrigemDestinoInvalida>(() => _viagem.RemarcarViagem(viagemParaRemarcar));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data/hora de origem não pode ser inferior a de destino!"));
        }

        [Test]
        public void RemarcarViagem_PassagemIdaEVolta_E_DatasPassagensInvalidas_RetornaViagemRemarcada()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            _viagem.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            viagemParaRemarcar.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");
            viagemParaRemarcar.PassagemVolta = new Passagem();
            viagemParaRemarcar.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-06 00:00:00");
            viagemParaRemarcar.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-05 00:00:00");

            // act
            DataHoraOrigemDestinoInvalida ex = Assert.Throws<DataHoraOrigemDestinoInvalida>(() => _viagem.RemarcarViagem(viagemParaRemarcar));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data/hora de origem não pode ser inferior a de destino!"));
        }

        [Test]
        public void RemarcarViagem_PassagemIdaEVolta_E_DatasViagensInvalidas_RetornaViagemRemarcada()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            _viagem.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-05 00:00:00");
            viagemParaRemarcar.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-06 00:00:00");
            viagemParaRemarcar.PassagemVolta = new Passagem();
            viagemParaRemarcar.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            viagemParaRemarcar.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");

            // act
            DataHoraIdaVoltaInvalida ex = Assert.Throws<DataHoraIdaVoltaInvalida>(() => _viagem.RemarcarViagem(viagemParaRemarcar));

            // assert
            Assert.That(ex.Message, Is.EqualTo("A data/hora de destino da passagem de ida não pode ser inferior a data/hora de origem da passagem de volta!"));
        }

        [Test]
        public void RemarcarViagem_PassagemVoltaExistente_E_PassagemRemarcadaComVoltaInexistente_DisparaExcecao()
        {
            // arrange
            _viagem.PassagemIda.DataHoraOrigem = Convert.ToDateTime("2000-01-01 00:00:00");
            _viagem.PassagemIda.DataHoraDestino = Convert.ToDateTime("2000-01-02 00:00:00");
            _viagem.PassagemVolta = new Passagem();
            _viagem.PassagemVolta.DataHoraOrigem = Convert.ToDateTime("2000-01-03 00:00:00");
            _viagem.PassagemVolta.DataHoraDestino = Convert.ToDateTime("2000-01-04 00:00:00");

            Viagem viagemParaRemarcar = new Viagem();
            viagemParaRemarcar.PassagemVolta = null;

            // act
            PassagensIncompativeis ex = Assert.Throws<PassagensIncompativeis>(() => _viagem.RemarcarViagem(viagemParaRemarcar));

            // assert
            Assert.That(ex.Message, Is.EqualTo("As passagens de ida e volta não correspondem com a nova entrada!"));
        }
    }
}