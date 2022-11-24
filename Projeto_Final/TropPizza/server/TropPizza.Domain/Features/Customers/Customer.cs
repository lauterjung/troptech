using System;
using TropPizza.Domain.Exceptions;

namespace TropPizza.Domain.Features.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public double FidelityPoints { get; set; }
        public bool HasFidelityDiscount
        {
            get { return CheckFidelityDiscount(); }
        }

        public Customer(string cpf, string fullName, DateTime birthDate, string address)
        {
            if (CheckValidBirthDate(birthDate) == false)
            {
                throw new InvalidDate();
            }

            Cpf = cpf;
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
            FidelityPoints = 0;
        }

        public Customer()
        {
        }

        // public double UseFidelityDiscount()
        // {
        //     throw new NotImplementedException();
        // }

        private bool CheckFidelityDiscount()
        {
            return FidelityPoints >= 10 ? true : false;
        }

        private bool CheckValidBirthDate(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.Date ? true : false;
        }
    }
}
