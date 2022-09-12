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
    public class FigurinhaController : ControllerBase
    {
        public List<Figurinha> listaFigurinhas = new List<Figurinha>()
        {
            new Figurinha(1, "A", 0),
            new Figurinha(2, "B", 0),
            new Figurinha(3, "C", 0),
            new Figurinha(4, "D", 0),
            new Figurinha(5, "E", 0),
            new Figurinha(6, "A", 1),
            new Figurinha(7, "A", 2),
            new Figurinha(8, "A", 3),
            new Figurinha(9, "A", 4)
        };

        [HttpGet]
        public List<Figurinha> Get()
        {
            return listaFigurinhas;
        }

        [HttpGet]
        [Route("{Numero}")]
        public Figurinha GetPorNumero(int numero)
        {
            Figurinha figurinhaBuscada = listaFigurinhas.Find(x => x.Numero == numero);

            return figurinhaBuscada;
        }

        [HttpPost]
        public List<Figurinha> Post([FromBody] Figurinha figurinha)
        {
            listaFigurinhas.Add(figurinha);
            return listaFigurinhas;
        }

        [HttpPut]
        public List<Figurinha> Put([FromBody] Figurinha figurinha)
        {
            Figurinha figurinhaBuscada = listaFigurinhas.Find(x => x.Numero == figurinha.Numero);
            figurinhaBuscada.Descricao = figurinha.Descricao;
            figurinhaBuscada.Tipo = figurinha.Tipo;
            return listaFigurinhas;
        }

        [HttpDelete]
        public List<Figurinha> Delete([FromBody] Figurinha figurinha)
        {
            Figurinha figurinhaBuscada = listaFigurinhas.Find(x => x.Numero == figurinha.Numero);
            listaFigurinhas.Remove(figurinhaBuscada);
            return listaFigurinhas;
        }
    }
}
