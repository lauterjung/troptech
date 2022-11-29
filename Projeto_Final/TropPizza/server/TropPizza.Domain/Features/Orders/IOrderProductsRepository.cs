using System;
using System.Collections.Generic;
using TropPizza.Domain.Features.Products;

namespace TropPizza.Domain.Features.Orders
{
    public interface IOrderProductsRepository
    {
        public void Create(Order order, Int64 lastKey);
        public Order ReadById(Int64 id);
        public void Delete(Int64 id);
    }
}