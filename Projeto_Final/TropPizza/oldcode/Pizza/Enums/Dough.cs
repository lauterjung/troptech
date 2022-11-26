using System.ComponentModel.DataAnnotations;

namespace TropPizza.Domain.Features.Products.Pizza.Enums
{
    public enum Dough
    {
        [Display(Name = "Tradicional")]
        Traditional = 0,
        
        [Display(Name = "Integral")]
        WholeWheat = 1,
    }
}