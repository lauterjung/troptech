

using TropPizza.Domain.Features.Products.Pizza.Enums;

namespace TropPizza.Domain.Features.Products.Pizza
{
    public class Crusting
    {
        public CrustingType Type { get; set; }
        public double Price { get; set; }

        public Crusting(CrustingType type)
        {
            Type = type;
        }

        public Crusting()
        {

        }

        // public double GetPrice() // varia cf. tamanho
        // {
        //     double price;

        //     switch (Type)
        //     {
        //         case CrustingType.Catupiry:
        //             price = 8.00;
        //             break;
        //         case CrustingType.Cheddar:
        //             price = 8.00;
        //             break;
        //         case CrustingType.Chocolate:
        //             price = 10.00;
        //             break;
        //         case CrustingType.None:
        //             price = 0.00;
        //             break;
        //         default:
        //             price = 0;
        //             break;
        //     }

        //     return price;
        // }
    }
}