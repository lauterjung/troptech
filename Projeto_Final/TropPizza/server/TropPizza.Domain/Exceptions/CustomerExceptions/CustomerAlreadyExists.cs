using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class CustomerAlreadyExists : Exception
    {
        public CustomerAlreadyExists() : base ("Cliente já existente!")
        {
        }

        public CustomerAlreadyExists(string message) : base(message)
        {

        }

        public CustomerAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}