using System;
using System.Collections.Generic;

namespace TropPizza.Domain.Features.Orders
{
    public interface IOrderRepository
    {
        public void Create(Order order);
        public Order ReadById(Int64 id);
        public List<Order> ReadAll();
        public void Delete(Int64 id);
    }
}