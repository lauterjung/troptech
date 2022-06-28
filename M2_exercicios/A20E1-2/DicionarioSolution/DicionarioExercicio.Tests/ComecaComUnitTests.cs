using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ComecaComUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMaiusculaComecaComStringMaiuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComString = new ComecaCom();

            var criterioAtingido = comecaComString.AvaliarCriterio("FOGO", "FO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMaiusculaComecaComStringMinuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComString = new ComecaCom();

            var criterioAtingido = comecaComString.AvaliarCriterio("FOGO", "fo");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMinusculaComecaComStringMaiuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComString = new ComecaCom();

            var criterioAtingido = comecaComString.AvaliarCriterio("fogo", "FO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoComecaComString_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var comecaComString = new ComecaCom();

            var criterioAtingido = comecaComString.AvaliarCriterio("fogo", "a");

            Assert.IsFalse(criterioAtingido);
        }
    }
}