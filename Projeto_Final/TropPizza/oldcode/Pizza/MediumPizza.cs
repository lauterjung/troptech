using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class MediumPizza : Pizza
    {
        public MediumPizza() : base()
        {
            Size = PizzaSize.Medium;
            Name = "Pizza média";
            UnitPrice = 61.90;
            Radius = 30;
            NumberOfSlices = 6;
            NumberOfToppings = 3;
        }
    }
}