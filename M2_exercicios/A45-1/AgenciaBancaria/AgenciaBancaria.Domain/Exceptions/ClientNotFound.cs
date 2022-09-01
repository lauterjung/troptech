using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ClientNotFound : Exception
    {
        public ClientNotFound() : base("Cliente não encontrado!")
        {
        }

        public ClientNotFound(string message) : base(message)
        {
        }

        public ClientNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}