using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class ZeroReservationsRegistered : Exception
    {
        public ZeroReservationsRegistered() : base("Nenhuma reserva encontrada!")
        {
        }

        public ZeroReservationsRegistered(string message) : base(message)
        {
        }

        public ZeroReservationsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroReservationsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}