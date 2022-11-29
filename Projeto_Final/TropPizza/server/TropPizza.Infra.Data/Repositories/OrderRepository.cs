using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Orders.Enums;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CustomerRepository _customerRepository = new CustomerRepository();
        private ProductRepository _productRepository = new ProductRepository();
        private OrderProductsRepository _orderProductsRepository = new OrderProductsRepository();
        private OrderDAO _orderDAO = new OrderDAO();

        public void Create(Order order)
        {
            if (order.Validate())
            {
                if (order.OrderCustomer != null)
                {
                    _customerRepository.ApplyFidelityPoints(order.OrderCustomer.Id, order.TotalPrice);
                }

                _orderDAO.Create(order);
                Int64 lastKey = _orderDAO.GetLastKey();
                _orderProductsRepository.Create(order, lastKey);

                foreach (Product product in order.Products)
                {
                    Product stockProduct = _productRepository.ReadById(product.Id);
                    stockProduct.RemoveFromInventory(product.Quantity);
                    _productRepository.Update(stockProduct);
                }
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

            searchedOrder.Products = _orderProductsRepository.ReadById(id);

            if (searchedOrder.CanBeDeleted())
            {
                if (searchedOrder.OrderCustomer != null)
                {
                    _customerRepository.ApplyFidelityPoints(searchedOrder.OrderCustomer.Id, -searchedOrder.TotalPrice);
                }

                if (searchedOrder.Status == OrderStatus.Pending)
                {
                    foreach (Product product in searchedOrder.Products)
                    {
                        Product stockProduct = _productRepository.ReadById(product.Id);
                        stockProduct.AddToInventory(product.Quantity);
                        _productRepository.Update(stockProduct);
                    }
                }

                _orderProductsRepository.Delete(id);
                _orderDAO.Delete(id);
            } else {
                
            }
        }
    }
}