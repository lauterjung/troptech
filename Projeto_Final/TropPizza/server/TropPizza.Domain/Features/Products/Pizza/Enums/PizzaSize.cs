using System.ComponentModel.DataAnnotations;

namespace TropPizza.Domain.Features.Products.Pizza.Enums
{
    public enum PizzaSize
    {
        [Display(Name = "Broto")]
        Small = 0,

        [Display(Name = "Média")]
        Medium = 1,

        [Display(Name = "Grande")]
        Large = 2,

        [Display(Name = "Gigante")]
        Giant = 3,
    }
}