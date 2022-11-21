
using TroptechProdutos.Domain;
using TroptechProdutos.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace TroptechProdutos.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private static ProductRepository _productRepository = new ProductRepository();

    public ProductController()
    {
    }

    [HttpGet]
    public ActionResult Get()
    {
        var products = _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Product product)
    {
        _productRepository.AddProduct(product);
        return Ok(true);
    }
}