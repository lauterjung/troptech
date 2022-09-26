using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class PassagemJaVinculada : Exception
    {
        public PassagemJaVinculada() : base ("A passagem já está vinculada!")
        {
        }

        public PassagemJaVinculada(string message) : base(message)
        {

        }

        public PassagemJaVinculada(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PassagemJaVinculada(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}