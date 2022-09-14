using System;
using System.Collections.Generic;
using System.Linq;

namespace Netflix.WebApi
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
        public bool EstaAtivo { get; set; }
        public Genero Genero { get; set; }
        public string NomeResumido
        {
            get { return $"{Titulo} - {AnoLancamento.ToString()} - {Genero.ToString()} - {MediaAvaliacoes.ToString()}"; }
        }
        public List<Avaliacao> ListaAvaliacoes { get; set; }
        public double MediaAvaliacoes
        {
            get { return CalcularMediaAvaliacoes(); }
        }

        public Filme(int id, string titulo, string sinopse, int anoLancamento, bool estaAtivo, Genero genero, List<Avaliacao> listaAvaliacoes)
        {
            Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            AnoLancamento = anoLancamento;
            EstaAtivo = estaAtivo;
            Genero = genero;
            ListaAvaliacoes = listaAvaliacoes;
        }

        public Filme()
        {

        }

        public void Avaliar(Avaliacao avaliacao)
        {
            ListaAvaliacoes.Add(avaliacao);
        }

        public double CalcularMediaAvaliacoes()
        {
            return ListaAvaliacoes.Select(x => x.Nota).Average();
        }
    }
}


