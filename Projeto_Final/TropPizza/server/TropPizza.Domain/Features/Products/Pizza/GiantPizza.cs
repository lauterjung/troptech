using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class GiantPizza : Pizza
    {
        public GiantPizza() : base()
        {
            Size = PizzaSize.Giant;
            Name = "Pizza gigante";
            UnitPrice = 84.90;
            Radius = 40;
            NumberOfSlices = 12;
            NumberOfToppings = 4;
        }
    }
}