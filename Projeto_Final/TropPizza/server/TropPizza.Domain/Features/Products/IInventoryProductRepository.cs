using System;
using System.Collections.Generic;

namespace TropPizza.Domain.Features.Products
{
    public interface IInventoryProductRepository
    {
        public void Create(InventoryProduct inventoryProduct);
        public InventoryProduct ReadById(Int64 id);
        public List<InventoryProduct> ReadAll();
        public List<InventoryProduct> ReadVisible();
        public void Update(InventoryProduct inventoryProduct);
        public void Delete(Int64 id);
    }
}