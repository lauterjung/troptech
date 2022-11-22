using System.ComponentModel.DataAnnotations;

namespace TropPizza.Domain.Features.Products.Pizza.Enums
{
    public enum Ingredients
    {
        [Display(Name = "Orégano")]
        Oregano = 0,

        [Display(Name = "Molho de tomate")]
        TomatoSauce = 1,

        [Display(Name = "Queijo mussarela")]
        MozzarellaCheese,

        [Display(Name = "Manjericão")]
        Basil,

        Pepperoni,
        Olive,
        Onion,
        Tomato,
        spinach,
        ParmesanCheese,
        RicottaCheese,
        Egg,
        Mushroom,
        DriedTomato,
        Shrimp,
        Corn,
        Chicken,
        Catupiry,
        Ham,
        
    }
}