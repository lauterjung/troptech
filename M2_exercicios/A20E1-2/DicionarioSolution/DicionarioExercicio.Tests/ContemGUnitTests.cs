using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ContemGUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemGMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new ContemG();

            var criterioAtingido = contemG.AvaliarCriterio("Gato");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemGMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemG = new ContemG();

            var criterioAtingido = contemG.AvaliarCriterio("fogo");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoContemG_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var contemG = new ContemG();

            var criterioAtingido = contemG.AvaliarCriterio("homem");

            Assert.IsFalse(criterioAtingido);
        }
    }
}