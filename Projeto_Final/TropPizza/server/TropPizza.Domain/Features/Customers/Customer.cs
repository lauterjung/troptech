using System;
using System.Linq;
using TropPizza.Domain.Exceptions.CustomerExceptions;

namespace TropPizza.Domain.Features.Customers
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string Cpf { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public double FidelityPoints { get; set; }

        public Customer()
        {
            FidelityPoints = 0;
        }

        public void ApplyFidelityPoints(double totalPrice)
        {
            FidelityPoints += 2 * totalPrice;
            if (FidelityPoints < 0)
            {
                FidelityPoints = 0;
            }
        }

        private bool CheckValidCpf()
        {
            return (Cpf.All(char.IsDigit) && Cpf.Length == 11) ? true : false;
        }

        private bool CheckValidFullName()
        {
            return FullName.Length >= 3 ? true : false;
        }

        private bool CheckValidAddress()
        {
            return !String.IsNullOrEmpty(Address) ? true : false;
        }

        private bool CheckValidBirthDate()
        {
            return BirthDate <= DateTime.Now.Date ? true : false;
        }

        public bool Validate()
        {
            if (CheckValidCpf() == false)
            {
                throw new InvalidCpf();
            }
            if (CheckValidFullName() == false)
            {
                throw new InvalidFullName();
            }
            if (CheckValidAddress() == false)
            {
                throw new InvalidAddress();
            }
            if (CheckValidBirthDate() == false)
            {
                throw new InvalidBirthDate();
            }

            return true;
        }
    }
}