using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class DataHoraOrigemDestinoInvalida : Exception
    {
        public DataHoraOrigemDestinoInvalida() : base ("A data/hora de origem não pode ser inferior a de destino!")
        {
        }

        public DataHoraOrigemDestinoInvalida(string message) : base(message)
        {

        }

        public DataHoraOrigemDestinoInvalida(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataHoraOrigemDestinoInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}