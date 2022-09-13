using System;

namespace Netflix.WebApi
{
    public class Serie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeTemporadas { get; set; }
        public int AnoLancamento { get; set; }
        public bool EstaAtivo { get; set; }
        public Genero Genero { get; set; }
        public string NomeResumido
        {
            get { return $"{Titulo} - {AnoLancamento.ToString()} - {Genero.ToString()}"; }
        }

        public Serie(int id, string titulo, int quantidadeTemporadas, int anoLancamento, bool estaAtivo, Genero genero)
        {
            Id = id;
            Titulo = titulo;
            QuantidadeTemporadas = quantidadeTemporadas;
            AnoLancamento = anoLancamento;
            EstaAtivo = estaAtivo;
            Genero = genero;
        }

        public Serie()
        {

        }
    }
}


