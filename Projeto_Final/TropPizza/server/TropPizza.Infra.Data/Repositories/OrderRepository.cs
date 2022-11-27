using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CustomerRepository _customerRepository = new CustomerRepository();
        private OrderProductsRepository _orderProductsRepository = new OrderProductsRepository();
        private OrderDAO _orderDAO = new OrderDAO();

        public void Create(Order order)
        {
            // Order searchedOrder = _orderDAO.ReadById(order.Id); // get order ID!
            // if (searchedOrder != null)
            // {
            //     throw new AlreadyExists();
            // }

            if (order.Validate())
            {
                if (!String.IsNullOrEmpty(order.CustomerCpf))
                {
                    _customerRepository.ApplyFidelityPoints(order.CustomerCpf, order.TotalPrice);
                }

                _orderDAO.Create(order);
                Int64 lastKey = _orderDAO.GetLastKey();
                _orderProductsRepository.Create(order, lastKey);
                _orderProductsRepository.RemoveFromInventory(order.Products); // de quem é essa responsabilidade?
            }
        }

        public Order ReadById(Int64 id)
        {
            Order order = _orderDAO.ReadById(id);
            if (order is null)
            {
                throw new NotFound();
            }

            order.Products = _orderProductsRepository.ReadById(id);
            return order;
        }

        public List<Order> ReadAll()
        {
            List<Order> ordersList = _orderDAO.ReadAll();

            if (ordersList.Count == 0)
            {
                throw new NotFound();
            }

            foreach (Order order in ordersList)
            {
                order.Products = _orderProductsRepository.ReadById(order.Id);
            }
            return ordersList;
        }

        public void Delete(Int64 id)
        {
            Order searchedOrder = _orderDAO.ReadById(id);
            if (searchedOrder is null)
            {
                throw new NotFound();
            }

            // if (order.CustomerCpf)
            // {
            //     _customerRepository.RemoveFidelityPoints(order.CustomerCpf, order.TotalPrice);
            // }

            // _orderProductsRepository.AddToInventory(order.Products); // de quem é essa 
            _orderProductsRepository.Delete(id);
            _orderDAO.Delete(id);
        }
    }
}