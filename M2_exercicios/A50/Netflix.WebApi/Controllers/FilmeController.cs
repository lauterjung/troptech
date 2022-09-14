using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Netflix.WebApi.Controllers
{
    [ApiController]
    [Route("api/filme")]
    public class FilmeController : ControllerBase
    {
        static List<Filme> listaFilme = Listas.listaFilme;

        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            listaFilme.Add(novoFilme);
            return Ok(listaFilme);
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (listaFilme == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }
            return Ok(listaFilme);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == id);

            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            return Ok(filmeBuscado);
        }

        [HttpPut]
        public IActionResult Put(Filme filmeEditado)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == filmeEditado.Id);

            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            if (filmeBuscado.EstaAtivo)
            {
                return BadRequest(new Response(400, "Não é possível editar filmes ativos!"));
            }

            filmeBuscado.Titulo = filmeEditado.Titulo;
            filmeBuscado.Sinopse = filmeEditado.Sinopse;
            filmeBuscado.AnoLancamento = filmeEditado.AnoLancamento;
            filmeBuscado.Genero = filmeEditado.Genero;

            return Ok(filmeBuscado);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == id);

            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            listaFilme.Remove(filmeBuscado);
            return Ok(listaFilme);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == id);

            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            if (!filmeBuscado.EstaAtivo)
            {
                return BadRequest(new Response(400, "O filme já está desativado!"));
            }

            filmeBuscado.EstaAtivo = false;
            return Ok(listaFilme);
        }

        // avaliações
        [HttpPost]
        [Route("{id}/avaliacao")]
        public IActionResult Post(int id, [FromBody] Avaliacao avaliacao)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == id);
            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            filmeBuscado.Avaliar(avaliacao);
            return Ok(listaFilme);
        }

        [HttpGet]
        [Route("{idFilme}/avaliacao/{idAvaliacao}")]
        public IActionResult Get(int idFilme, int idAvaliacao)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == idFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            Avaliacao avaliacaoBuscada = filmeBuscado.ListaAvaliacoes.Find(a => a.Id == idAvaliacao);
            if (avaliacaoBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma avaliação encontrada!"));
            }

            return Ok(avaliacaoBuscada);
        }

        [HttpDelete]
        [Route("{idFilme}/avaliacao/{idAvaliacao}")]
        public IActionResult Delete(int idFilme, int idAvaliacao)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == idFilme);
            if (filmeBuscado == null)
            {
                return BadRequest(new Response(400, "Nenhum filme encontrado!"));
            }

            Avaliacao avaliacaoBuscada = filmeBuscado.ListaAvaliacoes.Find(a => a.Id == idAvaliacao);
            if (avaliacaoBuscada == null)
            {
                return BadRequest(new Response(400, "Nenhuma avaliação encontrada!"));
            }

            filmeBuscado.ListaAvaliacoes.Remove(avaliacaoBuscada);
            return Ok(avaliacaoBuscada);
        }
    }
}
