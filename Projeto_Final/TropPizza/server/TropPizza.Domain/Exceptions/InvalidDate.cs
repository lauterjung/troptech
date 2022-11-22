using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class InvalidDate : Exception
    {
        public InvalidDate() : base ("Data inválida!")
        {
        }

        public InvalidDate(string message) : base(message)
        {

        }

        public InvalidDate(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDate(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}