using System.Collections.Generic;

namespace AgenciaBancaria.Domain
{
    public interface IAccountRepository
    {
        public void AddAccount(Account account);
        public List<Account> SearchAllAccounts();
        public List<Account> SearchAccountsByClientId(string clientId);
    }
}