using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class ViagemJaExistente : Exception
    {
        public ViagemJaExistente() : base ("Viagem já existente!")
        {
        }

        public ViagemJaExistente(string message) : base(message)
        {

        }

        public ViagemJaExistente(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ViagemJaExistente(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}