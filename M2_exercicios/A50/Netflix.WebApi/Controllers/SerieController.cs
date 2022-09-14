using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Netflix.WebApi.Controllers
{
    [ApiController]
    [Route("api/serie")]
    public class SerieController : ControllerBase
    {
        static List<Serie> listaSerie = Listas.listaSerie;

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
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }
            return Ok(listaSerie);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == id);

            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            return Ok(serieBuscada);
        }

        [HttpPut]
        public IActionResult Put(Serie SerieEditado)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == SerieEditado.Id);

            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            if (serieBuscada.EstaAtivo)
            {
                return BadRequest(new Response(400, "Não é possível editar séries ativas!"));
            }

            serieBuscada.Titulo = SerieEditado.Titulo;
            serieBuscada.QuantidadeTemporadas = SerieEditado.QuantidadeTemporadas;
            serieBuscada.AnoLancamento = SerieEditado.AnoLancamento;
            serieBuscada.Genero = SerieEditado.Genero;

            return Ok(serieBuscada);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == id);

            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            listaSerie.Remove(serieBuscada);
            return Ok(listaSerie);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == id);

            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            if (!serieBuscada.EstaAtivo)
            {
                return BadRequest(new Response(400, "A série já está desativada!"));
            }

            serieBuscada.EstaAtivo = false;
            return Ok(listaSerie);
        }

        // avaliações
        [HttpPost]
        [Route("{id}/avaliacao")]
        public IActionResult Post(int id, [FromBody] Avaliacao avaliacao)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == id);
            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            serieBuscada.Avaliar(avaliacao);
            return Ok(listaSerie);
        }

        [HttpGet]
        [Route("{idSerie}/avaliacao/{idAvaliacao}")]
        public IActionResult Get(int idSerie, int idAvaliacao)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == idSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            Avaliacao avaliacaoBuscada = serieBuscada.ListaAvaliacoes.Find(a => a.Id == idAvaliacao);
            if (avaliacaoBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma avaliação encontrada!"));
            }

            return Ok(avaliacaoBuscada);
        }

        [HttpDelete]
        [Route("{idSerie}/avaliacao/{idAvaliacao}")]
        public IActionResult Delete(int idSerie, int idAvaliacao)
        {
            Serie serieBuscada = listaSerie.Find(a => a.Id == idSerie);
            if (serieBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma série encontrada!"));
            }

            Avaliacao avaliacaoBuscada = serieBuscada.ListaAvaliacoes.Find(a => a.Id == idAvaliacao);
            if (avaliacaoBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma avaliação encontrada!"));
            }

            serieBuscada.ListaAvaliacoes.Remove(avaliacaoBuscada);
            return Ok(avaliacaoBuscada);
        }
    }
}
