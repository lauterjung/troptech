using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class OrderNotFound : Exception
    {
        public OrderNotFound() : base ("Pedido não encontrado!")
        {
        }

        public OrderNotFound(string message) : base(message)
        {

        }

        public OrderNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}