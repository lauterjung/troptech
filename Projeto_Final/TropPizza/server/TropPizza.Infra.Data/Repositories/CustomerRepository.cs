using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Customers;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDAO _customerDAO = new CustomerDAO();

        public void Create(Customer customer)
        {
            Customer searchedCustomer = _customerDAO.ReadByCpf(customer.Cpf);
            if (searchedCustomer != null)
            {
                throw new AlreadyExists();
            }

            if (customer.Validate())
            {
                _customerDAO.Create(customer);
            }
        }

        public Customer ReadById(Int64 id)
        {
            Customer customer = _customerDAO.ReadById(id);
            if (customer is null)
            {
                throw new NotFound();
            }

            return customer;
        }

        public Customer ReadByCpf(string cpf)
        {
            Customer customer = _customerDAO.ReadByCpf(cpf);
            if (customer is null)
            {
                throw new NotFound();
            }

            return customer;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customersList = _customerDAO.ReadAll();
            if (customersList.Count == 0)
            {
                throw new NotFound();
            }

            return customersList;
        }

        public void Update(Customer customer)
        {
            // Customer existingCustomer = _customerDAO.ReadByCpf(customer.Cpf);
            // if (existingCustomer != null)
            // {
            //     throw new AlreadyExists();
            // }

            Customer searchedCustomer = _customerDAO.ReadById(customer.Id);
            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            if (customer.Validate())
            {
                _customerDAO.Update(customer);
            }
        }

        public void Delete(Int64 id)
        {
            // verificar se existem pedidos em aberto
            Customer searchedCustomer = _customerDAO.ReadById(id);
            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            _customerDAO.Delete(id);
        }

        public void ApplyFidelityPoints(string cpf, double totalPrice)
        {
            Customer searchedCustomer = _customerDAO.ReadByCpf(cpf);
            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            searchedCustomer.ApplyFidelityPoints(totalPrice);
            _customerDAO.Update(searchedCustomer);
        }
    }
}