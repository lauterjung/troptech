using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class RoomAlreadyBooked : Exception
    {
        public RoomAlreadyBooked() : base("Sala já reservada nesse horário!")
        {
        }

        public RoomAlreadyBooked(string message) : base(message)
        {
        }

        public RoomAlreadyBooked(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomAlreadyBooked(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}