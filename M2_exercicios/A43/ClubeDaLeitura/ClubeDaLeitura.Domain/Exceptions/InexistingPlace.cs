using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class InexistingPlace : Exception
    {
        public InexistingPlace() : base("Local não existente!")
        {
        }
    }
}