using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;

namespace Northwind.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerOperation _customerOperations;

        public CustomerController(ICustomerOperation customerOperations)
        {
            _customerOperations = customerOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _customerOperations.GetCustomer();
            return Ok(result);
        }
        [HttpGet("GetCustomer24")]
        public IActionResult Get31()
        {
            var result = _customerOperations.GetModel24();
            return Ok(result);
        }

    }
}
