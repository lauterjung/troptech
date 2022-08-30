using System;
using System.Runtime.Serialization;

namespace ContaDeLuz.Domain.Exceptions
{
    [Serializable]
    public class ElectricBillNotFound : Exception
    {
        public ElectricBillNotFound() : base ("Conta de luz não encontrada!")
        {
        }

        public ElectricBillNotFound(string message) : base(message)
        {

        }

        public ElectricBillNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ElectricBillNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}