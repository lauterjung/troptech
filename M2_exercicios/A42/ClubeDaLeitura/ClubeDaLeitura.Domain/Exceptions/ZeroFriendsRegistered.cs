using System;

namespace ClubeDaLeitura.Domain.Exceptions
{
    public class ZeroFriendsRegistered : Exception
    {
        public ZeroFriendsRegistered() : base("Nenhum amigo encontrado!")
        {
        }
    }
}