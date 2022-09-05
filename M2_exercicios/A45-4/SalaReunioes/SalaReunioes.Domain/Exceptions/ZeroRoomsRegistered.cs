using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class ZeroRoomsRegistered : Exception
    {
        public ZeroRoomsRegistered() : base("Nenhuma sala encontrada!")
        {
        }

        public ZeroRoomsRegistered(string message) : base(message)
        {
        }

        public ZeroRoomsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroRoomsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}