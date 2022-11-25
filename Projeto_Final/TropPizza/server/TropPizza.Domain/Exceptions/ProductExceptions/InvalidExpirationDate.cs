using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InvalidExpirationDate : Exception
    {
        public InvalidExpirationDate() : base ("A data de validade deve ser maior que a data atual!")
        {
        }

        public InvalidExpirationDate(string message) : base(message)
        {

        }

        public InvalidExpirationDate(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidExpirationDate(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}