using System.Collections.Generic;

namespace FigurinhasCopa.WebApi
{
    public class Selecao
    {
        public List<Figurinha> ListaFigurinhas { get; set; }

        public Selecao(List<Figurinha> listaFigurinhas)
        {
            ListaFigurinhas = listaFigurinhas;
        }
        public Selecao()
        {

        }
    }
}