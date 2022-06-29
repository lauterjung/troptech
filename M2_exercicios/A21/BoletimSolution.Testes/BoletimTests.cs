using NUnit.Framework;
using BoletimSolution.Library;
using System.Collections.Generic;
using System.Linq;

namespace BoletimSolution.Testes
{
    public class BoletimTests
    {
        // [SetUp]
        // public void Setup()
        // {

        // }

        [Test]
        public void QuandoInformarNotaDeUmBimestre10EForPrimeiroBimestreEntaoPreencherPrimeiroEspacoCom10()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");

            //Action
            boletim.InformarNota(10, 1);

            //Assert
            Assert.AreEqual(boletim.Notas[0], 10);
        }

        [Test]
        public void Quando_BuscarNotasMenoresQueSete_E_TodasAsNotasForemPreenchidasEAtenderemCondicao_Deve_RetornarTodasNotas()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");
            boletim.Notas = new double[4] { 4, 5, 6, 5 };

            List<double> listaResultado = boletim.Notas.ToList();

            //Action
            List<double> resultado = boletim.MostrarMenorQueSete();

            //Assert
            Assert.AreEqual(resultado.Count, 4);
            CollectionAssert.AreEqual(resultado, listaResultado);
        }

        [Test]
        public void Quando_BuscarNotasMenoresQueSete_E_SomenteUmaForPreenchidasEAtenderemCondicao_Deve_RetornarSomenteUma()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");
            boletim.Notas[1] = 5;
            List<double> listaEsperada = new List<double>() { 5 };

            //Action
            List<double> resultado = boletim.MostrarMenorQueSete();

            //Assert
            Assert.AreEqual(resultado.Count, 1);
            CollectionAssert.AreEqual(resultado, listaEsperada);
        }

        [Test]
        public void Quando_BuscarNotasMenoresQueSete_E_NenhumaNotaForPreenchidasEAtenderemCondicao_Deve_RetornarListaVazia()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");

            //Action
            List<double> resultado = boletim.MostrarMenorQueSete();

            //Assert
            Assert.AreEqual(resultado.Count, 0);
        }

        [Test]
        public void Quando_BuscarNotasMenoresQueSete_E_SomenteUmaForPreenchidasENaoAtenderemCondicao_Deve_RetornarListaVazia()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");
            boletim.Notas[1] = 10;

            //Action
            List<double> resultado = boletim.MostrarMenorQueSete();

            //Assert
            Assert.AreEqual(resultado.Count, 0);
        }

        [Test]
        public void Quando_CalcularMediaParcial_E_Semestre1For8ESemestre2For10_Deve_Retornar9()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");
            boletim.Notas[0] = 8;
            boletim.Notas[1] = 10;

            //Action
            double resultado = boletim.CalcularMediaParcial();

            //Assert
            Assert.AreEqual(resultado, 9);
        }
        [Test]
        public void Quando_CalcularMediaFinal_E_TiverTodasAsNotas_Deve_RetornarMediaFinal()
        {
            //Arrange
            Boletim boletim = new Boletim("Aluno1");
            boletim.Notas[0] = 8;
            boletim.Notas[1] = 10;
            boletim.Notas[2] = 8;
            boletim.Notas[3] = 10;

            //Action
            double resultado = boletim.CalcularMediaFinal();

            //Assert
            Assert.AreEqual(resultado, 9);
        }
    }
}