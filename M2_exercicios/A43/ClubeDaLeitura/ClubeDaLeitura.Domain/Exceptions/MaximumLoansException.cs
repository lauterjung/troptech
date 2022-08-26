using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class MaximumLoansException : Exception
    {
        public MaximumLoansException() : base("O amigo já possui empréstimo!")
        {
        }
    }
}