using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    public class InexistingBusinessBasket : Exception
    {
        public InexistingBusinessBasket() : base("Tipo de cesta inexistente!")
        {
        }

        public InexistingBusinessBasket(string message) : base(message)
        {
        }

        public InexistingBusinessBasket(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InexistingBusinessBasket(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}