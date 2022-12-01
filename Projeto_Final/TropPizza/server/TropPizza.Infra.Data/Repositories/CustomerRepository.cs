using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Customers;
using TropPizza.Domain.Features.Orders;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDAO _customerDAO = new CustomerDAO();
        private OrderDAO _orderDAO = new OrderDAO();
        private CartProductsDAO _cartProductsDAO = new CartProductsDAO();

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

        // public Customer ReadByCpf(string cpf)
        // {
        //     Customer customer = _customerDAO.ReadByCpf(cpf);
        //     if (customer is null)
        //     {
        //         throw new NotFound();
        //     }

        //     return customer;
        // }

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

            if (customer.Validate())
            {
                _customerDAO.Update(customer);
            }
        }

        public void Delete(Int64 id)
        {
            Customer searchedCustomer = _customerDAO.ReadById(id);
            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            List<Order> unfinishedOrders = _orderDAO.ReadUnfinishedOrders(id);
            if (unfinishedOrders.Count > 0)
            {
                foreach (Order order in unfinishedOrders)
                {
                    _cartProductsDAO.Delete(order.Id);
                    _orderDAO.Delete(order.Id);
                }
            }

            _customerDAO.Delete(id);
        }

        public void ApplyFidelityPoints(Int64 id, double totalPrice)
        {
            Customer searchedCustomer = _customerDAO.ReadById(id);
            if (searchedCustomer is null)
            {
                throw new NotFound();
            }

            searchedCustomer.ApplyFidelityPoints(totalPrice);
            _customerDAO.Update(searchedCustomer);
        }
    }
}