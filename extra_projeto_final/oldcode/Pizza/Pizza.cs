using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class Pizza : Product
    {
        public PizzaSize Size { get; set; }
        public int Radius { get; set; }
        public int NumberOfSlices { get; set; }
        public int NumberOfToppings { get; set; }
        public double Price { get; set; }
        public Toppings Toppings { get; set; }
        // public Crusting Crusting { get; set; }
        // public Dough Dough { get; set; }

        public Pizza() : base()
        {
        }

        private double CalculatePrice()
        {
            // levar em conta os toppings / tipo tradicional ou especial / proporção de pedaços tradicionais
            return 0;
        }

        private double CalculateIngredientsConsumption()
        {
            // levar em conta os toppings / tipo tradicional ou especial / proporção de pedaços tradicionais
            return 0;
        }
    }
}
