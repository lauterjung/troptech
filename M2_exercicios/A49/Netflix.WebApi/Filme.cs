using System;

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
            get { return $"{Titulo} - {AnoLancamento.ToString()} - {Genero.ToString()}"; }
        }

        public Filme(int id, string titulo, string sinopse, int anoLancamento, bool estaAtivo, Genero genero)
        {
            Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            AnoLancamento = anoLancamento;
            EstaAtivo = estaAtivo;
            Genero = genero;
        }
        
        public Filme()
        {

        }
    }
}


