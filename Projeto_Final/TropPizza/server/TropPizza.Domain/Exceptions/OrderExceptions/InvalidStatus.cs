using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.OrderExceptions
{
[Serializable]
    public class InvalidStatus : Exception
    {
        public InvalidStatus() : base ("O status do pedido é inválido!")
        {
        }

        public InvalidStatus(string message) : base(message)
        {

        }

        public InvalidStatus(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStatus(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}