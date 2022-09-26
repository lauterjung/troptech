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
    [Route("api/conta")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _repository;

        public ContaController()
        {
            _repository = new ContaRepository();
        }

        [HttpPost]
        public IActionResult Post(Conta conta)
        {
            _repository.CadastraNovaConta(conta);
            return Ok(conta);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Conta>listaContas = _repository.BuscarTodasContas();

            if (listaContas.Count == 0)
            {
                return BadRequest("Nenhuma conta encontrada!");
            }

            return Ok(listaContas);
        }

        [HttpGet]
        [Route("{cpf}")]
        public IActionResult GetById(long cpf)
        {
            List<Conta>listaContas = _repository.BuscarContasPorCliente(cpf);

            if (listaContas.Count == 0)
            {
                return BadRequest("Nenhuma conta encontrada!");
            }

            return Ok(listaContas);
        }
    }
}
