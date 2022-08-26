using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class UnavailableComicBook : Exception
    {
        public UnavailableComicBook() : base("Revista já está locada!")
        {
        }
    }
}