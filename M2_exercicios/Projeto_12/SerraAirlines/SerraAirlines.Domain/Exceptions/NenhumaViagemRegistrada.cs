using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class NenhumaViagemRegistrada : Exception
    {
        public NenhumaViagemRegistrada() : base ("Nenhuma viagem registrada!")
        {
        }

        public NenhumaViagemRegistrada(string message) : base(message)
        {

        }

        public NenhumaViagemRegistrada(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NenhumaViagemRegistrada(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}