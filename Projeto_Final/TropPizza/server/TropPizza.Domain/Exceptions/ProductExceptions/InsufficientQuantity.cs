using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InsufficientQuantity : Exception
    {
        public InsufficientQuantity() : base ("O produto não possui a quantidade desejada em estoque!")
        {
        }

        public InsufficientQuantity(string message) : base(message)
        {

        }

        public InsufficientQuantity(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientQuantity(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}