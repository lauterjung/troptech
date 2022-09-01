using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ExistingAccount : Exception
    {
        public ExistingAccount() : base("Conta já cadastrada!")
        {
        }

        public ExistingAccount(string message) : base(message)
        {
        }

        public ExistingAccount(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingAccount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}