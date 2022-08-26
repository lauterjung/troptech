using System;

namespace MercadoSeuZe.ClassLib.Exceptions
{
    public class InsuficientQuantityException : Exception
    {
        public InsuficientQuantityException() : base("Quantidade indisponível no estoque!")
        {
        }
    }
}