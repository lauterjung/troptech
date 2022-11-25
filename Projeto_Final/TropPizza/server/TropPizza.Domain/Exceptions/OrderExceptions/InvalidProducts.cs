using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.OrderExceptions
{
[Serializable]
    public class InvalidProducts : Exception
    {
        public InvalidProducts() : base ("O pedido deve conter pelo menos um produto!")
        {
        }

        public InvalidProducts(string message) : base(message)
        {

        }

        public InvalidProducts(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProducts(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}