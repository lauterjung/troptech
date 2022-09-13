using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Netflix.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        public static List<Serie> listaSerie = new List<Serie>()
        {
            new Serie(1, "Serie1", 1, 2001, true, Genero.Ação),
            new Serie(2, "Serie2", 2, 2002, false, Genero.Comédia),
            new Serie(3, "Serie3", 3, 2003, true, Genero.Documentário),
            new Serie(4, "Serie4", 4, 2004, false, Genero.Drama),
            new Serie(5, "Serie5", 5, 2005, true, Genero.Ficção),
        };

        [HttpPost]
        public IActionResult Post(Serie novaSerie)
        {
            listaSerie.Add(novaSerie);
            return Ok(listaSerie);
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (listaSerie == null)
            {
                return BadRequest("Nenhuma série encontrada!");
            }
            return Ok(listaSerie);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Serie SerieBuscada = listaSerie.Find(a => a.Id == id);

            if (SerieBuscada == null)
            {
                return BadRequest("Nenhuma série encontrada!");
            }

            return Ok(SerieBuscada);
        }

        [HttpPut]
        public IActionResult Put(Serie SerieEditado)
        {
            Serie SerieBuscada = listaSerie.Find(a => a.Id == SerieEditado.Id);

            if (SerieBuscada == null)
            {
                return BadRequest("Nenhuma série encontrada!");
            }

            if (SerieBuscada.EstaAtivo)
            {
                return BadRequest("Não é possível editar séries ativas!");
            }

            SerieBuscada.Titulo = SerieEditado.Titulo;
            SerieBuscada.QuantidadeTemporadas = SerieEditado.QuantidadeTemporadas;
            SerieBuscada.AnoLancamento = SerieEditado.AnoLancamento;
            SerieBuscada.Genero = SerieEditado.Genero;

            return Ok(SerieBuscada);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Serie SerieBuscada = listaSerie.Find(a => a.Id == id);

            if (SerieBuscada == null)
            {
                return BadRequest("Nenhuma série encontrada!");
            }

            listaSerie.Remove(SerieBuscada);
            return Ok(listaSerie);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id)
        {
            Serie SerieBuscada = listaSerie.Find(a => a.Id == id);

            if (SerieBuscada == null)
            {
                return BadRequest("Nenhuma série encontrada!");
            }

            if (!SerieBuscada.EstaAtivo)
            {
                return BadRequest("A série já está desativada!");
            }

            SerieBuscada.EstaAtivo = false;
            return Ok(listaSerie);
        }
    }
}
