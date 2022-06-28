using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ComecaComAUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueComecaComAMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComA = new ComecaComA();

            var criterioAtingido = comecaComA.AvaliarCriterio("Antes");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueComecaComAMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComA = new ComecaComA();

            var criterioAtingido = comecaComA.AvaliarCriterio("antes");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoComecaComA_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var comecaComA = new ComecaComA();

            var criterioAtingido = comecaComA.AvaliarCriterio("Bom");

            Assert.IsFalse(criterioAtingido);
        }
    }
}