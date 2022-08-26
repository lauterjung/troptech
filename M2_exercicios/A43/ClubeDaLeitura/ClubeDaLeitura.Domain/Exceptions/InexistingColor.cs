using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class InexistingColor : Exception
    {
        public InexistingColor() : base("Cor não existente!")
        {
        }
    }
}