using NUnit.Framework;
using AgendaExercicio.Library;
using System.Collections.Generic;

namespace AgendaExercicio.Tests
{
    public class AgendaTests
    {
        [Test]
        public void AdicionarContato_NewContact_ReturnsTrueAndAddsToList()
        {
            // arrange
            Contato contato = new Contato();
            contato.Nome = "A";
            contato.Telefone = "0";
            Agenda agenda = new Agenda();

            // act
            bool result = agenda.AdicionarContato(contato);

            // assert
            Assert.True(result);
        }

        [Test]
        public void AdicionarContato_ExistingContact_ReturnsFalse()
        {
            // arrange
            Contato contato = new Contato();
            contato.Nome = "A";
            contato.Telefone = "0";
            Contato contato2 = new Contato();
            contato2.Nome = "A";
            contato2.Telefone = "0";

            Agenda agenda = new Agenda();
            agenda.AdicionarContato(contato);

            // act
            bool result = agenda.AdicionarContato(contato2);

            // assert
            Assert.False(result);
        }

        [Test]
        public void RemoverContato_ExistingContact_ReturnsTrueAndRemovesFromList()
        {
            // arrange
            Contato contato = new Contato();
            contato.Nome = "A";
            contato.Telefone = "0";

            Agenda agenda = new Agenda();
            agenda.AdicionarContato(contato);

            // act
            bool result = agenda.RemoverContato("A");

            // assert
            Assert.True(result);
        }

        [Test]
        public void RemoverContato_NonExistingContact_ReturnsFalse()
        {
            // arrange
            Agenda agenda = new Agenda();

            // act
            bool result = agenda.RemoverContato("A");

            // assert
            Assert.False(result);
        }

        [Test]
        public void PesquisarContato_ExistingContact_ReturnsContact()
        {
            // arrange
            Contato contato = new Contato();
            contato.Nome = "A";
            contato.Telefone = "0";

            Agenda agenda = new Agenda();
            agenda.AdicionarContato(contato);

            // act
            Contato result = agenda.PesquisarContato("A");

            // assert
            Assert.AreEqual(result, contato);
        }

        [Test]
        public void PesquisarContato_NonExistingContact_ReturnsNull()
        {
            // arrange
            Agenda agenda = new Agenda();

            // act
            Contato result = agenda.PesquisarContato("A");

            // assert
            Assert.Null(result);
        }

        [Test]
        public void ObterNomesEmOrdemAlfabetica_ScrambledList_ReturnsSortedNames()
        {
            // arrange
            Contato contato = new Contato();
            contato.Nome = "A";
            contato.Telefone = "0";

            Contato contato2 = new Contato();
            contato2.Nome = "C";
            contato2.Telefone = "0";

            Contato contato3 = new Contato();
            contato3.Nome = "B";
            contato3.Telefone = "0";

            Agenda agenda = new Agenda();
            agenda.AdicionarContato(contato);
            agenda.AdicionarContato(contato2);
            agenda.AdicionarContato(contato3);

            List<string> expected = new List<string>() { "A", "B", "C" };

            // act
            List<string> result = agenda.ObterNomesEmOrdemAlfabetica();

            // assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}