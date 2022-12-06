using System;
using Microsoft.AspNetCore.Mvc;
using TropPizza.Domain.Features.Products;
using TropPizza.Infra.Data.Repositories;

namespace TropPizza.WebApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class InventoryProductController : Controller
    {
        private IInventoryProductRepository _repository;

        public InventoryProductController()
        {
            _repository = new InventoryProductRepository();
        }

        [HttpPost]
        public IActionResult Post([FromBody] InventoryProduct product)
        {
            try
            {
                _repository.Create(product);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _repository.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("visible")]
        public IActionResult GetVisible()
        {
            try
            {
                return StatusCode(200, _repository.ReadVisible());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var searchedProduct = _repository.ReadById(id);
                if (searchedProduct == null)
                {
                    return StatusCode(204, searchedProduct);
                }
                return StatusCode(200, searchedProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] InventoryProduct product)
        {
            try
            {
                _repository.Update(product);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}