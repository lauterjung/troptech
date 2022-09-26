using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class ClienteNaoEncontrado : Exception
    {
        public ClienteNaoEncontrado() : base ("Cliente não encontrado!")
        {
        }

        public ClienteNaoEncontrado(string message) : base(message)
        {

        }

        public ClienteNaoEncontrado(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClienteNaoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}