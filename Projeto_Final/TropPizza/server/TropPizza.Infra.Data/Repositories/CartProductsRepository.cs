using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders;
using TropPizza.Infra.Data.DAO;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Infra.Data.Repositories
{
    public class CartProductsRepository : ICartProductsRepository
    {
        private CartProductsDAO _cartProductsDAO = new CartProductsDAO();
        private OrderDAO _orderDAO = new OrderDAO();

        public void Create(Order order, Int64 lastKey)
        {
            foreach (CartProduct cartProduct in order.CartProducts)
            {
                _cartProductsDAO.Create(lastKey, cartProduct.Id, cartProduct.Quantity, cartProduct.TotalPrice);
            }
        }

        // public void RemoveFromInventory(List<CartProduct> products)
        // {
        //     foreach (CartProduct product in products)
        //     {
        //         CartProduct stockProduct = _productRepository.ReadById(product.Id);
        //         stockProduct.RemoveFromInventory(product.Quantity);
        //         _productRepository.Update(stockProduct);
        //     }
        // }

        public List<CartProduct> ReadById(Int64 id)
        {
            List<CartProduct> cartProducts = _cartProductsDAO.ReadAll(id);
            return cartProducts;
        }

        // faz nada além de chamar o DAO
        public void Delete(Int64 id)
        {
            _cartProductsDAO.Delete(id);
        }
    }
}