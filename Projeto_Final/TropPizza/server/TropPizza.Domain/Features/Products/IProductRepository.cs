using System.Collections.Generic;

namespace TropPizza.Domain.Features.Products
{
    public interface IProductRepository
    {
        public void Create(Product Product);
        public Product ReadById(int id);
        public List<Product> ReadAll();
        public void Update(Product Product);
        public void Delete(int id);
    }
}