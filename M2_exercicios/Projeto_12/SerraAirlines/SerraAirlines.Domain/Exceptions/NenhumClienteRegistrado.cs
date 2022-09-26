using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class NenhumClienteRegistrado : Exception
    {
        public NenhumClienteRegistrado() : base ("Nenhum cliente registrado!")
        {
        }

        public NenhumClienteRegistrado(string message) : base(message)
        {

        }

        public NenhumClienteRegistrado(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NenhumClienteRegistrado(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}