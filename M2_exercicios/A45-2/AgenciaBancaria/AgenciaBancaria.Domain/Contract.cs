using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciaBancaria.Domain.Enums;

namespace AgenciaBancaria.Domain
{
    public class Contract
    {
        public float Id { get; set; }
        public ContractTypes ContractType { get; set; }
        public double TotalValue { get; set; }
        public int NumberOfInstallments { get; set; }
        public double InstallmentValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Client ContractOwner { get; set; }

        public Contract(float id, ContractTypes contractType, double totalValue, int numberOfInstallments, DateTime startDate, Client contractOwner)
        {
            Id = id;
            ContractType = contractType;
            TotalValue = totalValue;
            NumberOfInstallments = numberOfInstallments;
            InstallmentValue = CalculateInstallmentValues();
            StartDate = startDate;
            EndDate = CalculateEndDate();
            ContractOwner = contractOwner;
        }

        public Contract()
        {
            ContractOwner = new Client();
        }

        public double CalculateInstallmentValues()
        {
            return TotalValue / NumberOfInstallments;
        }

        public DateTime CalculateEndDate()
        {
            return StartDate.AddMonths(NumberOfInstallments);
        }

        public override string ToString()
        {
            return $"Número: {Id} - Tipo: {ContractType} - Valor Total: R${TotalValue} - Número parcelas: {NumberOfInstallments} - Valor Parcela: R${InstallmentValue} - Data: início {StartDate.ToShortDateString()} final {EndDate?.ToShortDateString()} - CPF {ContractOwner.Cpf} - Nome: {ContractOwner.Name}";
        }
    }
}