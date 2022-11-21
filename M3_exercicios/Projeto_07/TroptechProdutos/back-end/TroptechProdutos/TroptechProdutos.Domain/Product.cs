namespace TroptechProdutos.Domain;
public class Product
{
    public string? Name { get; set; }
    public Int32 Quantity { get; set; }
    public double Price { get; set; }

    #nullable enable
    public Product()
    {  
    }

    public Product(string name, Int32 quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
