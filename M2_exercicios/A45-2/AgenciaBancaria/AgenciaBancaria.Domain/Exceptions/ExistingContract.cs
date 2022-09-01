using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ExistingContract : Exception
    {
        public ExistingContract() : base("Contrato já cadastrado!")
        {
        }

        public ExistingContract(string message) : base(message)
        {
        }

        public ExistingContract(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingContract(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}