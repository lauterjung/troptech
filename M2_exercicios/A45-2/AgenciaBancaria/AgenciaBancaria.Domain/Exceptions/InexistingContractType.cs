using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class InexistingContractType : Exception
    {
        public InexistingContractType() : base("Tipo de contrato inexistente!")
        {
        }

        public InexistingContractType(string message) : base(message)
        {
        }

        public InexistingContractType(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InexistingContractType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}