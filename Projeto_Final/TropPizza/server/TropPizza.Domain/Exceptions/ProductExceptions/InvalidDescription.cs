using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.ProductExceptions
{
[Serializable]
    public class InvalidDescription : Exception
    {
        public InvalidDescription() : base ("A descrição não pode ser vazia!")
        {
        }

        public InvalidDescription(string message) : base(message)
        {

        }

        public InvalidDescription(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDescription(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}