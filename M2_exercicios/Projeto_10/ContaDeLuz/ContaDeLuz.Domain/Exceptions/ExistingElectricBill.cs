using System;
using System.Runtime.Serialization;

namespace ContaDeLuz.Domain.Exceptions
{
    [Serializable]
    public class ExistingElectricBill : Exception
    {
        public ExistingElectricBill() : base ("Conta de luz já cadastrada para esse mês desse ano!")
        {
        }

        public ExistingElectricBill(string message) : base(message)
        {

        }

        public ExistingElectricBill(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistingElectricBill(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}