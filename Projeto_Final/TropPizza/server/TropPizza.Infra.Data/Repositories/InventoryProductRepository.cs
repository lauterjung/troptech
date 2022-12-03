using System;
using System.Collections.Generic;
using TropPizza.Domain.Exceptions;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.DAO;

namespace TropPizza.Infra.Data.Repositories
{
    public class InventoryProductRepository : IInventoryProductRepository
    {
        private InventoryProductDAO _inventoryProductDAO = new InventoryProductDAO();

        public void Create(InventoryProduct inventoryProduct)
        {
            InventoryProduct searchedProduct = _inventoryProductDAO.ReadUnique(inventoryProduct.Name, inventoryProduct.Description, inventoryProduct.ExpirationDate);
            if (searchedProduct != null)
            {
                throw new AlreadyExists();
            }

            if (inventoryProduct.Validate())
            {
                _inventoryProductDAO.Create(inventoryProduct);
            }
        }

        public InventoryProduct ReadById(Int64 id)
        {
            InventoryProduct inventoryProduct = _inventoryProductDAO.ReadById(id);
            if (inventoryProduct is null)
            {
                throw new NotFound();
            }

            return inventoryProduct;
        }

        public InventoryProduct ReadUnique(string name, string description, DateTime expirationDate)
        {
            InventoryProduct inventoryProduct = _inventoryProductDAO.ReadUnique(name, description, expirationDate);
            if (inventoryProduct is null)
            {
                throw new NotFound();
            }

            return inventoryProduct;
        }

        public List<InventoryProduct> ReadVisible()
        {
            List<InventoryProduct> inventoryProductsList = _inventoryProductDAO.ReadVisible();
            if (inventoryProductsList.Count == 0)
            {
                throw new NotFound();
            }

            return inventoryProductsList;
        }

        public List<InventoryProduct> ReadAll()
        {
            List<InventoryProduct> inventoryProductsList = _inventoryProductDAO.ReadAll();
            if (inventoryProductsList.Count == 0)
            {
                throw new NotFound();
            }

            return inventoryProductsList;
        }

        public void Update(InventoryProduct inventoryProduct)
        {
            InventoryProduct searchedProduct = _inventoryProductDAO.ReadById(inventoryProduct.Id);
            if (searchedProduct is null)
            {
                throw new NotFound();
            }

            if (inventoryProduct.Validate())
            {
                _inventoryProductDAO.Update(inventoryProduct);
            }
        }

        public void Delete(Int64 id)
        {
            InventoryProduct searchedProduct = _inventoryProductDAO.ReadById(id);
            if (searchedProduct is null)
            {
                throw new NotFound();
            }

            _inventoryProductDAO.Delete(id);
        }
    }
}