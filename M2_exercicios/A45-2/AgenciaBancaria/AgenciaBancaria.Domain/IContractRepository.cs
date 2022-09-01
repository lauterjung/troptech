using System.Collections.Generic;

namespace AgenciaBancaria.Domain
{
    public interface IContractRepository
    {
        public void AddContract(Contract contract);
        public List<Contract> SearchAllContracts();
        public List<Contract> SearchContractsByClientId(string clientId);
    }
}