using System;
using AgenciaBancaria.Domain.Enums;

namespace AgenciaBancaria.Domain
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int Digit { get; set; }
        public int Branch { get; set; }
        public AccountTypes Type { get; set; }
        public double Balance { get; set; }
        public double? Limit { get; set; }
        public DateTime OpeningDate { get; set; }
        public BusinessBaskets? BusinessBasket { get; set; }
        public Client Owner { get; set; }

        public Account(int accountNumber, int digit, int branch, AccountTypes type, double balance, double? limit, DateTime openingDate, BusinessBaskets? businessBasket, Client owner)
        {
            AccountNumber = accountNumber;
            Digit = digit;
            Branch = branch;
            Type = type;
            Balance = balance;
            Limit = limit;
            OpeningDate = openingDate;
            BusinessBasket = businessBasket;
            Owner = owner;
        }

        public Account()
        {
            Owner = new Client();
        }

        public override string ToString()
        {
            return $"CC: {AccountNumber}-{Digit} - Ag: {Branch} - Tipo: {Type} - Saldo: R${Balance} - Limite: R${Limit} - Data Abertura: {OpeningDate.ToShortDateString()} - Cesta: {BusinessBasket} - CPF: {Owner.Cpf}";
        }
    }
}