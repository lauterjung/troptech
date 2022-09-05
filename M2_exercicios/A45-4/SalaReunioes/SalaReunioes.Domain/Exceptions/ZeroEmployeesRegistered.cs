using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class ZeroEmployeesRegistered : Exception
    {
        public ZeroEmployeesRegistered() : base("Nenhum funcionário encontrado!")
        {
        }

        public ZeroEmployeesRegistered(string message) : base(message)
        {
        }

        public ZeroEmployeesRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroEmployeesRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}