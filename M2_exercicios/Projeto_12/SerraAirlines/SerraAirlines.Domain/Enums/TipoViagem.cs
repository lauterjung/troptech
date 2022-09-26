using System.ComponentModel.DataAnnotations;

namespace SerraAirlines.Domain.Enums
{
    public enum TipoViagem
    {
        [Display(Name = "Ida")]
        Ida = 0,
        
        [Display(Name = "Ida e volta")]
        Ida_e_volta = 1
    }
}