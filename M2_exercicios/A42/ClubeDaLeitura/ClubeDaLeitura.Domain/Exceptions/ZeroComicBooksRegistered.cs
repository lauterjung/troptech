using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class ZeroComicBooksRegistered : Exception
    {
        public ZeroComicBooksRegistered() : base("Nenhuma revusta encontrada!")
        {
        }
    }
}