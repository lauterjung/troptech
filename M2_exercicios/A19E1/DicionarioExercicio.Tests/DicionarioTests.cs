using NUnit.Framework;
using DicionarioExercicio.Library;
using System.Collections.Generic;

namespace DicionarioExercicio.Tests
{
    public class DicionarioTests
    {
        [Test]
        public void Pesquisar_ComecaComN_ReturnsCorrespondingWords()
        {
            // arrange
            ComecaComN comecaComN = new ComecaComN();
            Dicionario dicionario = new Dicionario();
            List<string> expected = new List<string> {"Natação"};
            // act
            List<string> result = dicionario.Pesquisar(comecaComN);

            // assert
            CollectionAssert.AreEqual(expected, result);
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Pesquisar_ContemG_ReturnsCorrespondingWords()
        {
            // arrange
            ContemG contemG = new ContemG();
            Dicionario dicionario = new Dicionario();
            List<string> expected = new List<string> { "Rugby", "Esgrima", "Manga" };

            // act
            List<string> result = dicionario.Pesquisar(contemG);

            // assert
            CollectionAssert.AreEqual(expected, result);
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Pesquisar_ContemP_ReturnsCorrespondingWords()
        {
            // arrange
            ContemP contemP = new ContemP();
            Dicionario dicionario = new Dicionario();
            List<string> expected = new List<string> { "Preto", "Paulo"};

            // act
            List<string> result = dicionario.Pesquisar(contemP);

            // assert
            CollectionAssert.AreEqual(expected, result);
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Pesquisar_TerminaComO_ReturnsCorrespondingWords()
        {
            // arrange
            TerminaComO terminaComO = new TerminaComO();
            Dicionario dicionario = new Dicionario();
            List<string> expected = new List<string> {  "Natação", "Branco", "Preto", "Amarelo", "Vermelho", "Paulo","Haroldo" };

            // act
            List<string> result = dicionario.Pesquisar(terminaComO);

            // assert
            CollectionAssert.AreEqual(expected, result);
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}