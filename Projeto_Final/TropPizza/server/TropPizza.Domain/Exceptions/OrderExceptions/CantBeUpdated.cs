using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.OrderExceptions
{
[Serializable]
    public class CantBeUpdated : Exception
    {
        public CantBeUpdated() : base ("Não é possível alterar pedidos entregues!")
        {
        }

        public CantBeUpdated(string message) : base(message)
        {

        }

        public CantBeUpdated(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantBeUpdated(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}