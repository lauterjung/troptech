using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.OrderExceptions
{
[Serializable]
    public class InvalidDeletion : Exception
    {
        public InvalidDeletion() : base ("Não é possível deletar pedidos finalizados!")
        {
        }

        public InvalidDeletion(string message) : base(message)
        {

        }

        public InvalidDeletion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDeletion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}