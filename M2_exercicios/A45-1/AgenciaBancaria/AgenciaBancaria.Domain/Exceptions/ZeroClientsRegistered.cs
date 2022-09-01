using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ZeroClientsRegistered : Exception
    {
        public ZeroClientsRegistered() : base("Nenhum cliente encontrado!")
        {
        }

        public ZeroClientsRegistered(string message) : base(message)
        {
        }

        public ZeroClientsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroClientsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}