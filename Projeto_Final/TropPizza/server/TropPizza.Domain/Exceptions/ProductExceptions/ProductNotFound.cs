using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions
{
[Serializable]
    public class ProductNotFound : Exception
    {
        public ProductNotFound() : base ("Produto não encontrado!")
        {
        }

        public ProductNotFound(string message) : base(message)
        {

        }

        public ProductNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}