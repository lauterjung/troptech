using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class BookLoanNotFound : Exception
    {
        public BookLoanNotFound() : base("Empréstimo não encontrado!")
        {
        }
    }
}