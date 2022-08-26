using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class ZeroBookLoansRegistered : Exception
    {
        public ZeroBookLoansRegistered() : base("Nenhum empréstimo encontrado!")
        {
        }
    }
}