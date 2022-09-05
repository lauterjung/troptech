using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class InexistingAvailableRoom : Exception
    {
        public InexistingAvailableRoom() : base("Sala não encontrada!")
        {
        }

        public InexistingAvailableRoom(string message) : base(message)
        {
        }

        public InexistingAvailableRoom(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InexistingAvailableRoom(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}