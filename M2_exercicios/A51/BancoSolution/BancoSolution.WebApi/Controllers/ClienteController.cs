using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BancoSolution.WebApi.Controllers
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

        [HttpGet]
        public IActionResult Get()
        {
            List<Cliente>listaClientes = _repository.BuscarTodosClientes();

            if (listaClientes.Count == 0)
            {
                return BadRequest("Nenhum cliente encontrado!");
            }

            return Ok(listaClientes);
        }

        [HttpGet]
        [Route("{cpf}")]
        public IActionResult GetById(long cpf)
        {
            Cliente clienteBuscado = _repository.BuscarClientePorCpf(cpf);

            if (clienteBuscado == null)
            {
                return BadRequest("Nenhum cliente encontrado!");
            }

            return Ok(clienteBuscado);
        }
    }
}
