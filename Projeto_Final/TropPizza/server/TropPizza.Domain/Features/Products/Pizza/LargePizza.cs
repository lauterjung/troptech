using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class LargePizza : Pizza
    {
        public LargePizza() : base()
        {
            Size = PizzaSize.Large;
            Name = "Pizza grande";
            UnitPrice = 69.90;
            Radius = 35;
            NumberOfSlices = 8;
            NumberOfToppings = 4;
        }
    }
}