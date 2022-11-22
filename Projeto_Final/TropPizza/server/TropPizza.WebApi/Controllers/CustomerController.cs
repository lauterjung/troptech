using System;
using Microsoft.AspNetCore.Mvc;
using TropPizza.Domain.Features.Customers;
using TropPizza.Infra.Data.Repositories;

namespace TropPizza.WebApi.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _repository = new CustomerRepository();

        public CustomerController()
        {
            _repository = new CustomerRepository();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                _repository.Create(customer);
                return StatusCode(200);
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
        public IActionResult GetById(string id)
        {
            try
            {
                var searchedCustomer = _repository.ReadById(id);
                if (searchedCustomer == null)
                {
                    return StatusCode(204, searchedCustomer);
                }
                return StatusCode(200, searchedCustomer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Customer customer)
        {
            try
            {
                _repository.Update(customer);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
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