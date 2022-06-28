using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class TerminaComOUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraTerminaComOMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new TerminaComO();

            var criterioAtingido = contemG.AvaliarCriterio("FOGO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueTerminaComOMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new TerminaComO();

            var criterioAtingido = contemG.AvaliarCriterio("fogo");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoTerminaComO_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var contemG = new TerminaComO();

            var criterioAtingido = contemG.AvaliarCriterio("ordem");

            Assert.IsFalse(criterioAtingido);
        }
    }
}