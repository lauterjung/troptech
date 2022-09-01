using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data.DAO;

namespace AgenciaBancaria.Infra.Data
{
    public class ContractRepository : IContractRepository
    {
        private ContractDAO _contractDAO = new ContractDAO();
        private ClientDAO _clientDAO = new ClientDAO();

        public void AddContract(Contract contract)
        {
            Contract existingContract = _contractDAO.SearchContractByContractNumber(contract.Id);

            if (existingContract is not null)
            {
                throw new ExistingContract();
            }

            _contractDAO.AddContract(contract);
        }

        public List<Contract> SearchContractsByClientId(string clientId)
        {
            List<Contract> contractList = _contractDAO.SearchContractsByClientId(clientId);

            if (contractList.Count == 0)
            {
                throw new ContractNotFound();
            }

            return contractList;
        }

        public List<Contract> SearchAllContracts()
        {
            List<Contract> contractList = _contractDAO.SearchAllContracts();

            if (contractList.Count == 0)
            {
                throw new ZeroContractsRegistered();
            }

            return contractList;
        }
    }
}