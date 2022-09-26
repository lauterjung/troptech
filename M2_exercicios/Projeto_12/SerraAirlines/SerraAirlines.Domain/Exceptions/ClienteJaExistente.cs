using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class ClienteJaExistente : Exception
    {
        public ClienteJaExistente() : base ("Cliente já existente!")
        {
        }

        public ClienteJaExistente(string message) : base(message)
        {

        }

        public ClienteJaExistente(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClienteJaExistente(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}