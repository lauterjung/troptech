using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ComecaComNUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueComecaComNMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComN = new ComecaComN();

            var criterioAtingido = comecaComN.AvaliarCriterio("Nenhum");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueComecaComNMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var comecaComN = new ComecaComN();

            var criterioAtingido = comecaComN.AvaliarCriterio("nenhum");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoComecaComN_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var comecaComN = new ComecaComN();

            var criterioAtingido = comecaComN.AvaliarCriterio("Amor");

            Assert.IsFalse(criterioAtingido);
        }
    }
}