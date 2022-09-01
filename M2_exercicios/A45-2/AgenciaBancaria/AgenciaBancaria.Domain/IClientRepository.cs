using System.Collections.Generic;

namespace AgenciaBancaria.Domain
{
    public interface IClientRepository
    {
        public List<Client> SearchAllClients();
        public Client SearchClientById(string clientId);
    }
}