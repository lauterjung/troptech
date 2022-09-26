using System;
using System.Runtime.Serialization;

namespace SerraAirlines.Domain.Exceptions
{
    [Serializable]
    public class EnderecoNaoEncontrado : Exception
    {
        public EnderecoNaoEncontrado() : base ("Endereço não encontrado!")
        {
        }

        public EnderecoNaoEncontrado(string message) : base(message)
        {

        }

        public EnderecoNaoEncontrado(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EnderecoNaoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}