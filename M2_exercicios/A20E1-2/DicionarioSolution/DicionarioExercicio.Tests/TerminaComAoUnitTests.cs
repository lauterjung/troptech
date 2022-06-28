using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class TerminaComAoUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraTerminaComAoMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var terminaComAo = new TerminaComAo();

            var criterioAtingido = terminaComAo.AvaliarCriterio("FOGÃO");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueTerminaComAoMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var terminaComAo = new TerminaComAo();

            var criterioAtingido = terminaComAo.AvaliarCriterio("fogão");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoTerminaComAo_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var terminaComAo = new TerminaComAo();

            var criterioAtingido = terminaComAo.AvaliarCriterio("ordem");

            Assert.IsFalse(criterioAtingido);
        }
    }
}