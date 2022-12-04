using System;
using Microsoft.AspNetCore.Mvc;
using TropPizza.Domain.Features.Orders;
using TropPizza.Infra.Data.Repositories;

namespace TropPizza.WebApi.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : Controller
    {
        private IOrderRepository _repository;

        public OrderController()
        {
            _repository = new OrderRepository();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                _repository.Create(order);
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
                return Ok(_repository.ReadAll());
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
                var searchedOrder = _repository.ReadById(id);
                if (searchedOrder == null)
                {
                    return StatusCode(204, searchedOrder);
                }
                return StatusCode(200, searchedOrder);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("key")]
        public IActionResult GetLastKey(int id)
        {
            try
            {
                Int64 lastKey = _repository.ReadLastKey();
                return StatusCode(200, lastKey);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult PatchStatus([FromBody] Order order)
        {
            try
            {
                _repository.UpdateStatus(order);
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
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}