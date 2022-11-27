using System.ComponentModel.DataAnnotations;

namespace TropPizza.Domain.Features.Products.Pizza.Enums
{
    public enum ToppingType
    {
        [Display(Name = "Tradicional")]
        Traditional = 0,

        [Display(Name = "Especial")]
        Special = 1,

        [Display(Name = "Doce")]
        Dessert = 2,
    }
}