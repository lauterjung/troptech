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
    [Route("api/viagem")]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemRepository _repository;

        public ViagemController()
        {
            _repository = new ViagemRepository();
        }

        [HttpPost]
        public IActionResult Post(Viagem viagem)
        {
            try
            {
                _repository.Marcar(viagem);
                return Ok($"Viagem {viagem.CodigoReserva} cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpGet]
        [Route("{cpf}")]
        public IActionResult GetPorCpf(string cpf)
        {
            try
            {
                List<Viagem> listaViagens = _repository.BuscarTodasDeUmCliente(cpf);
                return Ok(listaViagens);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody]Viagem viagem)
        {
            try
            {
                _repository.Remarcar(viagem);
                return Ok($"Viagem {viagem.CodigoReserva} remarcada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }
    }
}
