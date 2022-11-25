using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InvalidName : Exception
    {
        public InvalidName() : base ("O nome não pode ser vazio!")
        {
        }

        public InvalidName(string message) : base(message)
        {

        }

        public InvalidName(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidName(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}