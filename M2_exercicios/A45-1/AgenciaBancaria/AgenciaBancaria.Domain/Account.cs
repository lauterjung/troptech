using System;

namespace AgenciaBancaria.Domain
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int Digit { get; set; }
        public int Branch { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public double? Limit { get; set; }
        public DateTime OpeningDate { get; set; }
        public int? BusinessBasket { get; set; }
        public string OwnerCpf { get; set; }

        public Account(int accountNumber, int digit, int branch, string type, double balance, double? limit, DateTime openingDate, int? businessBasket, string ownerCpf)
        {
            AccountNumber = accountNumber;
            Digit = digit;
            Branch = branch;
            Type = type;
            Balance = balance;
            Limit = limit;
            OpeningDate = openingDate;
            BusinessBasket = businessBasket;
            OwnerCpf = ownerCpf;
        }

        public Account()
        {

        }

        public override string ToString()
        {
            return $"CC: {AccountNumber}-{Digit} - Ag: {Branch} - Tipo: {Type} - Saldo: R${Balance} - Limite: R${Limit} - Data Abertura: {OpeningDate.ToShortDateString()} - Cesta: {BusinessBasket} - CPF: {OwnerCpf}";
        }
    }
}