using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class ProductAlreadyExists : Exception
    {
        public ProductAlreadyExists() : base ("Produto já existente!")
        {
        }

        public ProductAlreadyExists(string message) : base(message)
        {

        }

        public ProductAlreadyExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}