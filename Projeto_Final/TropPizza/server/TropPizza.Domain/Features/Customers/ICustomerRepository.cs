using System;
using System.Collections.Generic;

namespace TropPizza.Domain.Features.Customers
{
    public interface ICustomerRepository
    {
        public void Create(Customer customer);
        public Customer ReadById(Int64 id);
        // public Customer ReadByCpf(string cpf);
        public List<Customer> ReadAll();
        public void Update(Customer customer);
        public void Delete(Int64 id);
    }
}