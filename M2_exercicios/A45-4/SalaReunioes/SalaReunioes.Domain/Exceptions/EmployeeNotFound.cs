using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class EmployeeNotFound : Exception
    {
        public EmployeeNotFound() : base("Nenhum funcionário encontrado!")
        {
        }

        public EmployeeNotFound(string message) : base(message)
        {
        }

        public EmployeeNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}