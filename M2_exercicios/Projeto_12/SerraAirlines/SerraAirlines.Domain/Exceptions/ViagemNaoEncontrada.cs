using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class ViagemNaoEncontrada : Exception
    {
        public ViagemNaoEncontrada() : base ("Viagem não encontrada!")
        {
        }

        public ViagemNaoEncontrada(string message) : base(message)
        {

        }

        public ViagemNaoEncontrada(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ViagemNaoEncontrada(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}