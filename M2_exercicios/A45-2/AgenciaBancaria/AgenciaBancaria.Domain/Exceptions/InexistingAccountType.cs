using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class InexistingAccountType : Exception
    {
        public InexistingAccountType() : base("Tipo de conta inexistente!")
        {
        }

        public InexistingAccountType(string message) : base(message)
        {
        }

        public InexistingAccountType(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InexistingAccountType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}