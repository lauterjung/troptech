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

        public void AddAccount(Account account)
        {
            Account existingAccount = _accountDAO.SearchAccountByAccountNumber(account.AccountNumber);

            if (existingAccount is not null)
            {
                throw new ExistingAccount();
            }

            _accountDAO.AddAccount(account);
        }

        public List<Account> SearchAccountsByClientId(string clientId)
        {
            List<Account> accountList = _accountDAO.SearchAccountsByClientId(clientId);

            if (accountList.Count == 0)
            {
                throw new AccountNotFound();
            }

            return accountList;
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