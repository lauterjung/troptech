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
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController()
        {
            _repository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                _repository.Registrar(cliente);
                return Ok(cliente);
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
                List<Cliente> listaClientes = _repository.BuscarTodos();
                return Ok(listaClientes);
            }
            catch (System.Exception ex)
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
                Cliente cliente = _repository.BuscarPorCpf(cpf);
                return Ok(cliente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpDelete]
        [Route("{cpf}")]
        public IActionResult DeletePorCpf(string cpf)
        {
            try
            {
                _repository.Deletar(cpf);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Cliente cliente)
        {
            try
            {
                _repository.Atualizar(cliente);
                return Ok($"Cliente {cliente.Nome} atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Resposta(500, ex.Message));
            }
        }
    }
}
