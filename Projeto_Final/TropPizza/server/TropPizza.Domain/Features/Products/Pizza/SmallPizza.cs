using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class SmallPizza : Pizza
    {
        public SmallPizza() : base()
        {
            Size = PizzaSize.Small;
            Name = "Pizza broto";
            UnitPrice = 48.5;
            Radius = 25;
            NumberOfSlices = 4;
            NumberOfToppings = 2;
        }
    }
}