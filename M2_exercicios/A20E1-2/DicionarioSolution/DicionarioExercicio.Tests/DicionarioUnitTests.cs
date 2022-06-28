using DicionarioExercicio.Library;
using NUnit.Framework;

namespace DicionarioExercicio.Tests
{
    public class DicionarioUnitTests
    {
        [Test]
        public void Quando_BuscarPalavrasQueTerminamComO_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new TerminaComO();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().EndsWith("o"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueComecaComN_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new ComecaComN();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().StartsWith("n"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueContemP_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new ContemP();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().Contains("p"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueContemG_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new ContemG();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().Contains("g"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueContemM_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new ContemM();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().Contains("m"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueComecaComA_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new ComecaComA();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().StartsWith("a"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueTerminamComAo_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscador = new TerminaComAo();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscador);

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().EndsWith("ão"));
            Assert.IsTrue(atendeAoCriterio);
        }
        [Test]
        public void Quando_BuscarPalavrasQueComecaComString_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscadorComParametro = new ComecaCom();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscadorComParametro, "a");

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().StartsWith("a"));
            Assert.IsTrue(atendeAoCriterio);
        }

        [Test]
        public void Quando_BuscarPalavrasQueTerminamComString_Entao_DeveRetornarApenasPalavrasQueAtendemAoCriterio()
        {
            var buscadorComParametro = new TerminaCom();
            var dicionario = new Dicionario();

            var palavras = dicionario.Pesquisar(buscadorComParametro, "a");

            var atendeAoCriterio = palavras.TrueForAll(y => y.ToLower().EndsWith("a"));
            Assert.IsTrue(atendeAoCriterio);
        }
    }
}
