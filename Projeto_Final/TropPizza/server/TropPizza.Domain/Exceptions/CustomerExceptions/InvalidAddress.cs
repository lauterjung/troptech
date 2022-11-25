using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.CustomerExceptions
{
[Serializable]
    public class InvalidAddress : Exception
    {
        public InvalidAddress() : base ("O endereço não pode ser vazio!")
        {
        }

        public InvalidAddress(string message) : base(message)
        {

        }

        public InvalidAddress(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAddress(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}