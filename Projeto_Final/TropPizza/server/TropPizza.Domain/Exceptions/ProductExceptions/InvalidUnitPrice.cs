using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InvalidUnitPrice : Exception
    {
        public InvalidUnitPrice() : base ("O preço unitário deve ser maior que zero!")
        {
        }

        public InvalidUnitPrice(string message) : base(message)
        {

        }

        public InvalidUnitPrice(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUnitPrice(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}