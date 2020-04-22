using learn_dotnet.Interfaces;
using learn_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace learn_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _repository.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public IActionResult Get(string id)
        {
            var customer = _repository.Get(id);
            if (customer == null) {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] Customer customer)
        {
            var newCustomer = _repository.Create(customer);
            return Ok(newCustomer);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateCustomer(string id, Customer newCustomer)
        {
            var customer = _repository.Get(id);
            if (customer == null) {
                return NotFound();
            }

            _repository.Update(id, newCustomer);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var customer = _repository.Get(id);
            if (customer == null) {
                return NotFound();
            }

            _repository.Delete(customer.Id);
            return NoContent();
        }
    }
}