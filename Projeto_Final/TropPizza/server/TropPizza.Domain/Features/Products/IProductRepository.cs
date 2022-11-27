using System;
using System.Collections.Generic;

namespace TropPizza.Domain.Features.Products
{
    public interface IProductRepository
    {
        public void Create(Product product);
        public Product ReadById(Int64 id);
        public Product ReadUnique(string name, string description, DateTime expirationDate);
        public List<Product> ReadAll();
        public void Update(Product product);
        public void Delete(Int64 id);
    }
}