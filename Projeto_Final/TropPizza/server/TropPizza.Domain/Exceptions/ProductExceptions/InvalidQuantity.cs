using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InvalidQuantity : Exception
    {
        public InvalidQuantity() : base ("A quantidade deve ser maior ou igual a zero!")
        {
        }

        public InvalidQuantity(string message) : base(message)
        {

        }

        public InvalidQuantity(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidQuantity(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}