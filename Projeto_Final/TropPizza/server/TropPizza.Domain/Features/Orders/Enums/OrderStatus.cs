using System.ComponentModel.DataAnnotations;

namespace TropPizza.Domain.Features.Orders.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Pendente")]
        Pending = 0,

        [Display(Name = "Em preparo")]
        Preparation = 1,

        [Display(Name = "Saiu para entrega")]
        Deliver = 2,

        [Display(Name = "Finalizado")]
        Finished = 3,
    }
}