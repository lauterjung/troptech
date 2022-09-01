using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class ZeroContractsRegistered : Exception
    {
        public ZeroContractsRegistered() : base("Nenhum contrato encontrado!")
        {
        }

        public ZeroContractsRegistered(string message) : base(message)
        {
        }

        public ZeroContractsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroContractsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}