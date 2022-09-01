using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ContractNotFound : Exception
    {
        public ContractNotFound() : base("Contrato não encontrado!")
        {
        }

        public ContractNotFound(string message) : base(message)
        {
        }

        public ContractNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContractNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}