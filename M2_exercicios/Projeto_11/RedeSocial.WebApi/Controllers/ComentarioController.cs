using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.WebApi;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentarioController : ControllerBase
    {
        public List<Comentario> listaComentario = new List<Comentario>()
        {
            new Comentario(1, "Commentario1", new DateTime(2022, 08, 23), "Miguel", 0, 1),
            new Comentario(2, "Commentario2", new DateTime(2022, 08, 24), "Miguel", 0, 2),
            new Comentario(3, "Commentario3", new DateTime(2022, 08, 25), "Miguel", 0, 3),
            new Comentario(4, "Commentario4", new DateTime(2022, 08, 26), "Miguel", 0, 4),
            new Comentario(5, "Commentario5", new DateTime(2022, 08, 27), "Miguel", 0, 5),
        };

        [HttpGet]
        [Route("{id}")]
        public Comentario GetPorId(int id)
        {
            var comentarioBuscado = listaComentario.Find(a => a.IdComentario == id);
            return comentarioBuscado;
        }

        [HttpGet]
        [Route("publicacao/{publicacaoId}")]
        public Comentario GetPorPublicacaoId(int publicacaoId)
        {
            var comentarioBuscado = listaComentario.Find(a => a.IdPublicacao == publicacaoId);
            return comentarioBuscado;
        }

        [HttpPost]
        public List<Comentario> Post([FromBody] Comentario novoComentario)
        {
            listaComentario.Add(novoComentario);
            return listaComentario;
        }

        [HttpPut]
        [Route("{id}")]
        public List<Comentario> PutCurtir(int id)
        {
            var comentarioBuscado = listaComentario.Find(a => a.IdComentario == id);
            comentarioBuscado.Curtidas += 1;
            return listaComentario;
        }

        [HttpDelete]
        [Route("{id}")]
        public List<Comentario> Delete(int id)
        {
            var comentarioBuscado = listaComentario.Find(a => a.IdComentario == id);
            listaComentario.Remove(comentarioBuscado);
            return listaComentario;
        }
    }
}