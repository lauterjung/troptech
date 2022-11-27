using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class Toppings
    {
        public string Name { get; set; }
        public ToppingType ToppingType { get; set; }
        public Ingredients Ingredients { get; set; }
    }
}
