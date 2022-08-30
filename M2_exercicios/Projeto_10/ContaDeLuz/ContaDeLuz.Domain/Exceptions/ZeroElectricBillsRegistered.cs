using System;
using System.Runtime.Serialization;

namespace ContaDeLuz.Domain.Exceptions
{
    [Serializable]
    public class ZeroElectricBillsRegistered : Exception
    {
        public ZeroElectricBillsRegistered() : base ("Nenhuma conta de luz registrada!")
        {
        }

        public ZeroElectricBillsRegistered(string message) : base(message)
        {

        }

        public ZeroElectricBillsRegistered(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroElectricBillsRegistered(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}