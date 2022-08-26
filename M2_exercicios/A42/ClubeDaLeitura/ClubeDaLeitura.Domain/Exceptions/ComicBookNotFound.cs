using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class ComicBookNotFound : Exception
    {
        public ComicBookNotFound() : base("Revista não encontrada!")
        {
        }
    }
}