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
            Customer searchedCustomer = _customerDAO.ReadById(customer.Id);

            if (searchedCustomer != null)
            {
                throw new AlreadyExists();
            }

            _customerDAO.Create(customer);
        }

        public Customer ReadById(string id)
        {
            Customer customer = _customerDAO.ReadById(id);

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
            Customer searchedCustomer = _customerDAO.ReadById(customer.Id);

            if (searchedCustomer is null)
            {
                throw new NotFound();
            }
            
            _customerDAO.Update(customer);
        }

        public void Delete(string id)
        {
            Customer searchedCustomer = _customerDAO.ReadById(id);

            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            _customerDAO.Delete(searchedCustomer);
        }
    }
}