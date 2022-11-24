using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductDAO _productDAO = new ProductDAO();

        public void Create(Product product)
        {
            Product searchedProduct = _productDAO.ReadUnique(product.Name, product.Description, product.ExpirationDate);

            if (searchedProduct != null)
            {
                throw new AlreadyExists();
            }

            _productDAO.Create(product);
        }

        public Product ReadById(int id)
        {
            Product product = _productDAO.ReadById(id);

            if (product is null)
            {
                throw new NotFound();
            }

            return product;
        }

        public Product ReadUnique(string name, string description, DateTime expirationDate)
        {
            Product product = _productDAO.ReadUnique(name, description, expirationDate);

            if (product is null)
            {
                throw new NotFound();
            }

            return product;
        }

        public List<Product> ReadAll()
        {
            List<Product> ProductsList = _productDAO.ReadAll();

            if (ProductsList.Count == 0)
            {
                throw new NotFound();
            }

            return ProductsList;
        }

        public void Update(Product product)
        {
            Product searchedProduct = _productDAO.ReadById(product.Id);

            if (searchedProduct is null)
            {
                throw new NotFound();
            }
            
            _productDAO.Update(product);
        }

        public void Delete(int id)
        {
            Product searchedProduct = _productDAO.ReadById(id);

            if (searchedProduct is null)
            {
                throw new NotFound();
            }

            _productDAO.Delete(searchedProduct);
        }
    }
}