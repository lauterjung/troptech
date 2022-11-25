using System;
using System.Linq;
using TropPizza.Domain.Exceptions.CustomerExceptions;
using TropPizza.Domain.Features.Orders;

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
        }

        public double ApplyFidelityPoints(Order order) 
        {
            throw new NotImplementedException();
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
            return String.IsNullOrEmpty(Address) ? false : true;
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
