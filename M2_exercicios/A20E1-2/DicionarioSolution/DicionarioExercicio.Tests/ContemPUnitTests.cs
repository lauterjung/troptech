using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ContemPUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemPMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new ContemP();

            var criterioAtingido = contemG.AvaliarCriterio("PAPEL");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemPMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new ContemP();

            var criterioAtingido = contemG.AvaliarCriterio("tapa");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoContemP_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var contemG = new ContemP();

            var criterioAtingido = contemG.AvaliarCriterio("homem");

            Assert.IsFalse(criterioAtingido);
        }
    }
}