using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class TerminaComUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMaiusculaTerminaComStringMaiuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var terminaComString = new TerminaCom();

            var criterioAtingido = terminaComString.AvaliarCriterio("FOGO", "GO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMaiusculaTerminaComStringMinuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var terminaComString = new TerminaCom();

            var criterioAtingido = terminaComString.AvaliarCriterio("FOGO", "go");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraMinusculaTerminaComStringMaiuscula_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var terminaComString = new TerminaCom();

            var criterioAtingido = terminaComString.AvaliarCriterio("fogo", "GO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoTerminaComString_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var terminaComString = new TerminaCom();

            var criterioAtingido = terminaComString.AvaliarCriterio("fogo", "a");

            Assert.IsFalse(criterioAtingido);
        }
    }
}