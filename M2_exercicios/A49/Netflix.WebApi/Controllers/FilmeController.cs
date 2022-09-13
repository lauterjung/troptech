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
    public class FilmeController : ControllerBase
    {
        public static List<Filme> listaFilme = new List<Filme>()
        {
            new Filme(1, "Filme1", "Sinopse1", 2001, true, Genero.Ação),
            new Filme(2, "Filme2", "Sinopse2", 2002, false, Genero.Comédia),
            new Filme(3, "Filme3", "Sinopse3", 2003, true, Genero.Documentário),
            new Filme(4, "Filme4", "Sinopse4", 2004, false, Genero.Drama),
            new Filme(5, "Filme5", "Sinopse5", 2005, true, Genero.Ficção),
        };

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
                return BadRequest("Nenhum filme encontrado!");
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
                return BadRequest("Nenhum filme encontrado!");
            }

            return Ok(filmeBuscado);
        }

        [HttpPut]
        public IActionResult Put(Filme filmeEditado)
        {
            Filme filmeBuscado = listaFilme.Find(a => a.Id == filmeEditado.Id);

            if (filmeBuscado == null)
            {
                return BadRequest("Nenhum filme encontrado!");
            }

            if (filmeBuscado.EstaAtivo)
            {
                return BadRequest("Não é possível editar filmes ativos!");
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
                return BadRequest("Nenhum filme encontrado!");
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
                return BadRequest("Nenhum filme encontrado!");
            }

            if (!filmeBuscado.EstaAtivo)
            {
                return BadRequest("O filme já está desativado!");
            }

            filmeBuscado.EstaAtivo = false;
            return Ok(listaFilme);
        }
    }
}
