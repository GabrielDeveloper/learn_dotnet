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

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] Customer customer)
        {
            var newCustomer = _repository.Create(customer);
            var customers = _repository.GetAll();
            return Ok(customers);
        }

    }
}