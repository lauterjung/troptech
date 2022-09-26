using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class PassagensIncompativeis : Exception
    {
        public PassagensIncompativeis() : base ("As passagens de ida e volta não correspondem com a nova entrada!")
        {
        }

        public PassagensIncompativeis(string message) : base(message)
        {

        }

        public PassagensIncompativeis(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PassagensIncompativeis(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}