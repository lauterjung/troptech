using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class ValorInvalido : Exception
    {
        public ValorInvalido() : base ("O valor da passagem deve ser maior que zero!")
        {
        }

        public ValorInvalido(string message) : base(message)
        {

        }

        public ValorInvalido(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValorInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}