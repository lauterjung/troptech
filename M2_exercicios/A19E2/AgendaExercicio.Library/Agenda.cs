using System.Collections.Generic;
using System.Linq;

namespace AgendaExercicio.Library
{
    public class Agenda
    {
        private List<Contato> contatos;

        public Agenda()
        {
            this.contatos = new List<Contato>();
        }

        public Agenda(List<Contato> contatos)
        {
            this.contatos = contatos;
        }

        public bool AdicionarContato(Contato contato)
        {
            Contato contatoExistente = this.PesquisarContato(contato.Nome);
            if (contatoExistente == null)
            {
                this.contatos.Add(contato);
                return true;
            }
            return false;
        }

        public bool RemoverContato(string nomeDoContato)
        {
            Contato contatoExistente = this.PesquisarContato(nomeDoContato);
            if (contatoExistente != null)
            {
                this.contatos.Remove(contatoExistente);
                return true;
            }
            return false;
        }

        public Contato PesquisarContato(string nomeDoContato)
        {
            foreach (Contato contato in this.contatos)
            {
                if (contato.Nome == nomeDoContato)
                {
                    return contato;
                }
            }

            return null;
        }

        public List<string> ObterNomesEmOrdemAlfabetica()
        {
            return this.contatos.OrderBy(y => y.Nome).Select(y=>y.Nome).ToList();
        }
    }
}
	