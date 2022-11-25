using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.CustomerExceptions
{
[Serializable]
    public class InvalidCpf : Exception
    {
        public InvalidCpf() : base ("O CPF precisa conter 11 dígitos numéricos!")
        {
        }

        public InvalidCpf(string message) : base(message)
        {

        }

        public InvalidCpf(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCpf(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}