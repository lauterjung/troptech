using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.CustomerExceptions
{
[Serializable]
    public class InvalidFullName : Exception
    {
        public InvalidFullName() : base ("O nome completo precisa ter pelo menos 3 caracteres!")
        {
        }

        public InvalidFullName(string message) : base(message)
        {

        }

        public InvalidFullName(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFullName(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}