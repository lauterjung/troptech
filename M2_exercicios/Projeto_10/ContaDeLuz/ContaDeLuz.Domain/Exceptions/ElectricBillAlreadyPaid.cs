using System;
using System.Runtime.Serialization;

namespace ContaDeLuz.Domain.Exceptions
{
    [Serializable]
    public class ElectricBillAlreadyPaid : Exception
    {
        public ElectricBillAlreadyPaid() : base ("Conta de luz já está paga!")
        {
        }

        public ElectricBillAlreadyPaid(string message) : base(message)
        {

        }

        public ElectricBillAlreadyPaid(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ElectricBillAlreadyPaid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}