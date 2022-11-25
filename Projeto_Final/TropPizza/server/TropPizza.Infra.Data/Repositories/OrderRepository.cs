using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Orders;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDAO _orderDAO = new OrderDAO();

        public void Create(Order order)
        {
            Order searchedOrder = _orderDAO.ReadById(order.Id);
            if (searchedOrder != null)
            {
                throw new AlreadyExists();
            }

            if (order.Validate())
            {
                _orderDAO.Create(Order);
            }
        }

        public Order ReadById(Int64 id)
        {
            Order order = _orderDAO.ReadById(id);
            if (Order is null)
            {
                throw new NotFound();
            }

            return Order;
        }

        public List<Order> ReadAll()
        {
            List<Order> OrdersList = _orderDAO.ReadAll();

            if (OrdersList.Count == 0)
            {
                throw new NotFound();
            }

            return OrdersList;
        }

        public void Update(Order order)
        {
            Order searchedOrder = _orderDAO.ReadById(order.Id);
            if (searchedOrder is null)
            {
                throw new NotFound();
            }
            
            if (order.Validate())
            {
                _orderDAO.Update(Order);
            }
        }

        public void Delete(Int64 id)
        {
            // verificar se existem pedidos em aberto
            Order searchedOrder = _orderDAO.ReadById(id);

            if (searchedOrder is null)
            {
                throw new NotFound();
            }

            _orderDAO.Delete(id);
        }
    }
}