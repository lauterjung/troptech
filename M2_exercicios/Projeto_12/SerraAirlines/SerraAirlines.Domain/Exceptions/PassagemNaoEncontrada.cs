using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class PassagemNaoEncontrada : Exception
    {
        public PassagemNaoEncontrada() : base ("Passagem não encontrada!")
        {
        }

        public PassagemNaoEncontrada(string message) : base(message)
        {

        }

        public PassagemNaoEncontrada(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PassagemNaoEncontrada(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}