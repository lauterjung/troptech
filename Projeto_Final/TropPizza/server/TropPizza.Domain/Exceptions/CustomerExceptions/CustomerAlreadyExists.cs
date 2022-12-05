using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class CpfAlreadyExists : Exception
    {
        public CpfAlreadyExists() : base ("CPF já existente!")
        {
        }

        public CpfAlreadyExists(string message) : base(message)
        {

        }

        public CpfAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CpfAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}