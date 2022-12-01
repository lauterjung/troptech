using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Orders;

namespace TropPizza.Domain.Features.Products
{
    public interface ICartProductsRepository
    {
        public void Create(Order order, Int64 lastKey);
        public List<CartProduct> ReadById(Int64 id);
        public void Delete(Int64 id);
    }
}