using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class OrderProductsRepository : IOrderProductsRepository
    {
        private OrderProductsDAO _orderProductsDAO = new OrderProductsDAO();
        private OrderDAO _orderDAO = new OrderDAO();
        private ProductRepository _productRepository = new ProductRepository();

        public void Create(Order order, Int64 lastKey)
        {
            foreach (Product product in order.Products)
            {
                _orderProductsDAO.Create(lastKey, product.Id, product.Quantity, product.TotalPrice);
            }
        }

        // public void RemoveFromInventory(List<Product> products)
        // {
        //     foreach (Product product in products)
        //     {
        //         Product stockProduct = _productRepository.ReadById(product.Id);
        //         stockProduct.RemoveFromInventory(product.Quantity);
        //         _productRepository.Update(stockProduct);
        //     }
        // }

        public List<Product> ReadById(Int64 id)
        {
            List<Product> products = _orderProductsDAO.ReadAll(id);
            return products;
        }

        // faz nada além de chamar o DAO
        public void Delete(Int64 id)
        {
            _orderProductsDAO.Delete(id);
        }

        Order IOrderProductsRepository.ReadById(long id)
        {
            throw new NotImplementedException();
        }
    }
}