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
    [Route("api/contrato")]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoRepository _repository;

        public ContratoController()
        {
            _repository = new ContratoRepository();
        }

        [HttpPost]
        public IActionResult Post(Contrato contrato)
        {
            _repository.CadastraNovoContrato(contrato);
            return Ok(contrato);
        }

        [HttpGet]
        [Route("{cpf}")]
        public IActionResult GetById(long cpf)
        {
            List<Contrato>listaContratos = _repository.BuscarContratosPorCliente(cpf);

            if (listaContratos.Count == 0)
            {
                return BadRequest("Nenhuma Contrato encontrada!");
            }

            return Ok(listaContratos);
        }
    }
}
