using System;
using System.Runtime.Serialization;

namespace TropPizza.Domain.Exceptions.CustomerExceptions
{
[Serializable]
    public class InvalidBirthDate : Exception
    {
        public InvalidBirthDate() : base ("A data de nascimento precisa ser inferior ao dia de hoje!")
        {
        }

        public InvalidBirthDate(string message) : base(message)
        {

        }

        public InvalidBirthDate(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBirthDate(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}