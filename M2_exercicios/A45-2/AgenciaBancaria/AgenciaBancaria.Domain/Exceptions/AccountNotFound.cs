using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class AccountNotFound : Exception
    {
        public AccountNotFound() : base("Conta não encontrada!")
        {
        }

        public AccountNotFound(string message) : base(message)
        {
        }

        public AccountNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}