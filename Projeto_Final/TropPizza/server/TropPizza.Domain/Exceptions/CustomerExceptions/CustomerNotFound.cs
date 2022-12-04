using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class CustomerNotFound : Exception
    {
        public CustomerNotFound() : base ("Cliente não encontrado!")
        {
        }

        public CustomerNotFound(string message) : base(message)
        {

        }

        public CustomerNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}