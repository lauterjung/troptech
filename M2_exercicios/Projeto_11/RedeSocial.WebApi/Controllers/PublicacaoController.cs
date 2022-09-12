using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.WebApi;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicacaoController : ControllerBase
    {
        public List<Publicacao> listaPublicacao = new List<Publicacao>()
        {
            new Publicacao(1, "Post1", new DateTime(2022, 08, 22), "Miguel", 0),
            new Publicacao(2, "Post2", new DateTime(2022, 08, 23), "Miguel", 1),
            new Publicacao(3, "Post3", new DateTime(2022, 08, 24), "Miguel", 2),
            new Publicacao(4, "Post4", new DateTime(2022, 08, 25), "Miguel", 3),
        };

        [HttpGet]
        [Route("{id}")]
        public Publicacao GetPorId(int id)
        {
            var publicacaoBuscada = listaPublicacao.Find(a => a.IdPublicacao == id);
            return publicacaoBuscada;
        }

        [HttpPost]
        public List<Publicacao> Post([FromBody] Publicacao novaPublicacao)
        {
            listaPublicacao.Add(novaPublicacao);
            return listaPublicacao;
        }

        [HttpPut]
        public List<Publicacao> Put([FromBody] Publicacao publicacaoEditada)
        {
            var publicacaoBuscada = listaPublicacao.Find(a => a.IdPublicacao == publicacaoEditada.IdPublicacao);
            publicacaoBuscada.DataPublicacao = publicacaoEditada.DataPublicacao;
            return listaPublicacao;
        }

        [HttpPut]
        [Route("{id}")]
        public List<Publicacao> PutCurtir(int id)
        {
            var publicacaoBuscada = listaPublicacao.Find(a => a.IdPublicacao == id);
            publicacaoBuscada.Curtidas += 1;
            return listaPublicacao;
        }

        [HttpDelete]
        [Route("{id}")]
        public List<Publicacao> Delete(int id)
        {
            var publicacaoBuscada = listaPublicacao.Find(a => a.IdPublicacao == id);
            listaPublicacao.Remove(publicacaoBuscada);
            return listaPublicacao;
        }
    }
}