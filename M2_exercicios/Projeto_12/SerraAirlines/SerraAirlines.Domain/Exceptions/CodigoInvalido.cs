using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class CodigoInvalido : Exception
    {
        public CodigoInvalido() : base ("O código é inválido, deve possuir 6 letras!")
        {
        }

        public CodigoInvalido(string message) : base(message)
        {

        }

        public CodigoInvalido(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CodigoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}