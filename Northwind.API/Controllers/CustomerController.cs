using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.BusinessModels;

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
       
        [HttpPost]
        public IActionResult Post([FromBody] CustomerRegistrPostModel model)
        {
            if (ModelState.IsValid)
                _customerOperations.Add(model);
            else
                return BadRequest();
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit([FromBody] ChangeCustomerModel model)
        {
            var res = _customerOperations.Edit(model);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] string id)
        {
           _customerOperations.Remove(id);
            return Ok();
        }
        [HttpGet("Total")]
        public IActionResult Totalcustomers()
        {
            var res = _customerOperations.GetTotalCustomers();
            return Ok(res);
        }

        [HttpGet("listByRegion")]
        public IActionResult Get24()
        {
            var result = _customerOperations.GetCustomerlistbyregions();
            return Ok(result);
        }
        [HttpGet("HighValue")]
        public IActionResult HighValue()
        {
            var result = _customerOperations.GetHighvaluecustomers();
            return Ok(result);
        }

        [HttpGet("HighValueTotalOrders")]
        public IActionResult HighValueTotalOrders()
        {
            var result = _customerOperations.Highvaluecustomerstotalorders();
            return Ok(result);
        }
    }
}
