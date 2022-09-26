using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class PassagensRepetidas : Exception
    {
        public PassagensRepetidas() : base ("A passagem de ida é igual a passagem de volta!")
        {
        }

        public PassagensRepetidas(string message) : base(message)
        {

        }

        public PassagensRepetidas(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PassagensRepetidas(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}