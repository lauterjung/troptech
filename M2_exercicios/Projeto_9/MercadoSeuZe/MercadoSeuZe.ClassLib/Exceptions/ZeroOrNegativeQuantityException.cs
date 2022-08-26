using System;

namespace MercadoSeuZe.ClassLib.Exceptions
{
    public class ZeroOrNegativeQuantityException : Exception
    {
        public ZeroOrNegativeQuantityException() : base("Quantidade deve ser maior do que zero!")
        {
        }
    }
}