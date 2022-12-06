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
                throw new ProductAlreadyExists();
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
                throw new ProductNotFound();
            }

            return inventoryProduct;
        }

        public List<InventoryProduct> ReadVisible()
        {
            List<InventoryProduct> inventoryProductsList = _inventoryProductDAO.ReadVisible();
            if (inventoryProductsList.Count == 0)
            {
                throw new ProductNotFound();
            }

            return inventoryProductsList;
        }

        public List<InventoryProduct> ReadAll()
        {
            List<InventoryProduct> inventoryProductsList = _inventoryProductDAO.ReadAll();
            if (inventoryProductsList.Count == 0)
            {
                throw new ProductNotFound();
            }

            return inventoryProductsList;
        }

        public void Update(InventoryProduct inventoryProduct)
        {
            InventoryProduct searchedProduct = _inventoryProductDAO.ReadById(inventoryProduct.Id);
            if (searchedProduct is null)
            {
                throw new ProductNotFound();
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
                throw new ProductNotFound();
            }

            _inventoryProductDAO.Delete(id);
        }
    }
}