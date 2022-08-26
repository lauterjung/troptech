using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class FriendNotFound : Exception
    {
        public FriendNotFound() : base("Amigo não encontrado!")
        {
        }
    }
}