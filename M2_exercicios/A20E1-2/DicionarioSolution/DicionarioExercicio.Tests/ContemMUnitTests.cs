using NUnit.Framework;
using DicionarioExercicio.Library;

namespace DicionarioExercicio.Tests
{
    public class ContemMUnitTests
    {
        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemMMaiusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemM = new ContemM();

            var criterioAtingido = contemM.AvaliarCriterio("Mato");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueContemMMinusculo_Entao_DeveRetornarQueCriterioFoiAtendido()
        {
            var contemM = new ContemM();

            var criterioAtingido = contemM.AvaliarCriterio("fome");

            Assert.IsTrue(criterioAtingido);
        }

        [Test]
        public void Quando_AvaliarCriterio_E_CompararComPalavraQueNaoContemM_Entao_DeveRetornarQueCriterioNaoFoiAtendido()
        {
            var contemM = new ContemM();

            var criterioAtingido = contemM.AvaliarCriterio("fogo");

            Assert.IsFalse(criterioAtingido);
        }
    }
}