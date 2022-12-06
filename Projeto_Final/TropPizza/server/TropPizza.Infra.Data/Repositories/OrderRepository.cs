using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Exceptions.OrderExceptions;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CustomerRepository _customerRepository = new CustomerRepository();
        private InventoryProductRepository _inventoryProductRepository = new InventoryProductRepository();
        private CartProductsRepository _cartProductsRepository = new CartProductsRepository();
        private OrderDAO _orderDAO = new OrderDAO();

        public void Create(Order order)
        {
            if (order.Validate())
            {
                if (order.OrderCustomer != null)
                {
                    order.OrderCustomer = _customerRepository.ReadByCpf(order.OrderCustomer.Cpf);
                    _customerRepository.ApplyFidelityPoints(order.OrderCustomer.Id, order.TotalPrice);
                }

                _orderDAO.Create(order);
                Int64 lastKey = _orderDAO.ReadLastKey();
                _cartProductsRepository.Create(order, lastKey);

                foreach (CartProduct cartProduct in order.CartProducts)
                {
                    InventoryProduct inventoryProduct = _inventoryProductRepository.ReadById(cartProduct.Id);
                    inventoryProduct.RemoveFromInventory(cartProduct.Quantity);
                    _inventoryProductRepository.Update(inventoryProduct);
                }
            }
        }

        public Order ReadById(Int64 id)
        {
            Order order = _orderDAO.ReadById(id);
            if (order is null)
            {
                throw new OrderNotFound();
            }

            order.CartProducts = _cartProductsRepository.ReadById(id);
            return order;
        }

        public List<Order> ReadAll()
        {
            List<Order> ordersList = _orderDAO.ReadAll();

            if (ordersList.Count == 0)
            {
                throw new OrderNotFound();
            }

            foreach (Order order in ordersList)
            {
                order.CartProducts = _cartProductsRepository.ReadById(order.Id);
            }
            return ordersList;
        }

        public Int64 ReadLastKey()
        {
            return _orderDAO.ReadLastKey();
        }

        public void UpdateStatus(Order order)
        {
            Order searchedOrder = _orderDAO.ReadById(order.Id);
            if (searchedOrder is null)
            {
                throw new OrderNotFound();
            }

            if (searchedOrder.CanBeUpdated() == false)
            {
                throw new CantBeUpdated();
            }

            if (order.Validate())
            {
                _orderDAO.UpdateStatus(order);
            }
        }

        public void Delete(Int64 id)
        {
            Order searchedOrder = _orderDAO.ReadById(id);
            if (searchedOrder is null)
            {
                throw new OrderNotFound();
            }

            if (searchedOrder.CanBeUpdated() == false)
            {
                throw new CantBeUpdated();
            }

            searchedOrder.CartProducts = _cartProductsRepository.ReadById(id);

            if (searchedOrder.OrderCustomer != null)
            {
                _customerRepository.ApplyFidelityPoints(searchedOrder.OrderCustomer.Id, -searchedOrder.TotalPrice);
            }

            if (searchedOrder.StatusEnum == OrderStatus.Pending)
            {
                foreach (CartProduct cartProduct in searchedOrder.CartProducts)
                {
                    InventoryProduct inventoryProduct = _inventoryProductRepository.ReadById(cartProduct.Id);
                    inventoryProduct.AddToInventory(cartProduct.Quantity);
                    _inventoryProductRepository.Update(inventoryProduct);
                }
            }

            _cartProductsRepository.Delete(id);
            _orderDAO.Delete(id);
        }
    }
}