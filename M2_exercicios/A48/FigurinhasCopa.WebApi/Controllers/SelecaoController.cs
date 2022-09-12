using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FigurinhasCopa.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelecaoController : ControllerBase
    {
        public static List<Figurinha> figurinhasSelecao1 = new List<Figurinha>()
        {
            new Figurinha(1, "A", 0),
            new Figurinha(2, "B", 0),
            new Figurinha(3, "C", 0),
            new Figurinha(4, "D", 0),
        };
        public static List<Figurinha> figurinhasSelecao2 = new List<Figurinha>()
        {
            new Figurinha(5, "A", 0),
            new Figurinha(6, "B", 0),
            new Figurinha(7, "C", 0),
            new Figurinha(8, "D", 0),
        };

        public List<Selecao> listaSelecoes = new List<Selecao>()
        {
            new Selecao(figurinhasSelecao1),
            new Selecao(figurinhasSelecao2)
        };

        [HttpGet]
        public List<Selecao> Get()
        {
            return listaSelecoes;
        }
    }
}
