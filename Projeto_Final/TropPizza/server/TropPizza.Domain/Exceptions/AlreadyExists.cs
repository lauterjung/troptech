using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class AlreadyExists : Exception
    {
        public AlreadyExists() : base ("Entidade já existente!")
        {
        }

        public AlreadyExists(string message) : base(message)
        {

        }

        public AlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}