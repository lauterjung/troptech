using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data.DAO;

namespace AgenciaBancaria.Infra.Data
{
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO _accountDAO = new AccountDAO();
        private ClientDAO _clientDAO = new ClientDAO();

        public void TryExistingClient(string clientId)
        {
            Client searchedClient = _clientDAO.SearchClientById(clientId);
            if (searchedClient is null)
            {
                throw new ClientNotFound();
            }
        }

        public void AddAccount(Account account)
        {
            _accountDAO.AddAccount(account);
        }

        public Account SearchAccountByClientId(string clientId)
        {
            Account searchedAccount = _accountDAO.SearchAccountByClientId(clientId);

            if (searchedAccount is null)
            {
                throw new AccountNotFound();
            }

            return searchedAccount;
        }

        public List<Account> SearchAllAccounts()
        {
            List<Account> accountList = _accountDAO.SearchAllAccounts();

            if (accountList.Count == 0)
            {
                throw new ZeroAccountsRegistered();
            }

            return accountList;
        }
    }
}