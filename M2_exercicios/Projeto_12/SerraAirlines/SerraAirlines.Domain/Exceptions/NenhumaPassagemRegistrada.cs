using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class NenhumaPassagemRegistrada : Exception
    {
        public NenhumaPassagemRegistrada() : base ("Nenhuma passagem registrada!")
        {
        }

        public NenhumaPassagemRegistrada(string message) : base(message)
        {

        }

        public NenhumaPassagemRegistrada(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NenhumaPassagemRegistrada(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}