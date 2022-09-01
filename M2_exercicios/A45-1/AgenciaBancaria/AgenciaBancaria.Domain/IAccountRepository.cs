using System.Collections.Generic;

namespace AgenciaBancaria.Domain
{
    public interface IAccountRepository
    {
        public void AddAccount(Account account);
        public List<Account> SearchAllAccounts();
        public Account SearchAccountByClientId(string clientId);
        public void TryExistingClient(string clientId);
    }
}