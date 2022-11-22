using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class NotFound : Exception
    {
        public NotFound() : base ("Não encontrado!")
        {
        }

        public NotFound(string message) : base(message)
        {

        }

        public NotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}