using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class EmptyReport : Exception
    {
        public EmptyReport() : base("Relatório vazio!")
        {
        }
    }
}