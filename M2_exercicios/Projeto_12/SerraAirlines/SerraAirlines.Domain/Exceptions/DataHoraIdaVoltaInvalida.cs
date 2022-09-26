using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class DataHoraIdaVoltaInvalida : Exception
    {
        public DataHoraIdaVoltaInvalida() : base ("A data/hora de destino da passagem de ida não pode ser inferior a data/hora de origem da passagem de volta!")
        {
        }

        public DataHoraIdaVoltaInvalida(string message) : base(message)
        {

        }

        public DataHoraIdaVoltaInvalida(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataHoraIdaVoltaInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}