using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SerraAirlines.Domain;
using SerraAirlines.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SerraAirlines.WebApi.Controllers
{
    [ApiController]
    [Route("api/passagem")]
    public class PassagemController : ControllerBase
    {
        private readonly IPassagemRepository _repository;

        public PassagemController()
        {
            _repository = new PassagemRepository();
        }

        [HttpPost]
        public IActionResult Post(Passagem passagem)
        {
            try
            {
                _repository.Adicionar(passagem);
                return Ok(passagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Passagem> listaPassagems = _repository.BuscarTodas();
                return Ok(listaPassagems);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpGet]
        [Route("por-data")]
        public IActionResult GetPorData(DateTime data)
        {
            try
            {
                List<Passagem> listaPassagens = _repository.BuscarPorData(data);
                return Ok(listaPassagens);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpGet]
        [Route("por-origem")]
        public IActionResult GetPorOrigem([FromQuery]string origem)
        {
            try
            {
                List<Passagem> listaPassagens = _repository.BuscarPorOrigem(origem);
                return Ok(listaPassagens);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpGet]
        [Route("por-destino")]
        public IActionResult GetPorDestino(string destino)
        {
            try
            {
                List<Passagem> listaPassagens = _repository.BuscarPorDestino(destino);
                return Ok(listaPassagens);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Passagem passagem)
        {
            try
            {
                _repository.Atualizar(passagem);
                return Ok($"Passagem {passagem.Id} atualizada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }
    }
}
