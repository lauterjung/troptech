using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data.DAO;

namespace AgenciaBancaria.Infra.Data
{
    public class ClientRepository : IClientRepository
    {
        private ClientDAO _clientDAO = new ClientDAO();

        public List<Client> SearchAllClients()
        {
            List<Client> clientList = _clientDAO.SearchAllClients();

            if (clientList.Count == 0)
            {
                throw new ZeroClientsRegistered();
            }

            return clientList;
        }

        public Client SearchClientById(string clientId)
        {
            Client searchedClient = _clientDAO.SearchClientById(clientId);

            if (searchedClient is null)
            {
                throw new ClientNotFound();
            }

            return searchedClient;
        }
    }
}