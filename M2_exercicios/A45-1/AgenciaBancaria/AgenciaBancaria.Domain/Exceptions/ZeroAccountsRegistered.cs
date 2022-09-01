using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ZeroAccountsRegistered : Exception
    {
        public ZeroAccountsRegistered() : base("Nenhuma conta encontrada!")
        {
        }

        public ZeroAccountsRegistered(string message) : base(message)
        {
        }

        public ZeroAccountsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroAccountsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}