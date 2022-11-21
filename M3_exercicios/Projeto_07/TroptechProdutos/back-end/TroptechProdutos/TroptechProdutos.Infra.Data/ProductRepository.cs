using TroptechProdutos.Domain;

namespace TroptechProdutos.Infra.Data;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>() {
            new Product("Aaa", 10, 10.50),
            new Product("Bbb", 20, 20.50),
            new Product("Ccc", 30, 30.50),
            new Product("Ddd", 30, 40.50),
            new Product("Eee", 30, 50.50)
        };
    }

    public List<Product> GetProducts() {
        return _products;
    }

    public void AddProduct (Product product) {
         _products.Add(product);
    }
}
