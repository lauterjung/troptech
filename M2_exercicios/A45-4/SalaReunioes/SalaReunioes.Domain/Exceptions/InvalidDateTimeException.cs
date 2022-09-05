using System;
using System.Runtime.Serialization;

namespace SalaReunioes.Domain.Exceptions
{
    [Serializable]
    public class InvalidDateTimeException : Exception
    {
        public InvalidDateTimeException() : base("Data/hora inválida!")
        {
        }

        public InvalidDateTimeException(string message) : base(message)
        {
        }

        public InvalidDateTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}