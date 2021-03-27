using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Core.BusinessModels;

using Northwind.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;

namespace Northwind.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperations _orderOperations;

        public OrderController(IOrderOperations orderOperations)
        {
            _orderOperations = orderOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderOperations.GetOrders();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {

            var result = _orderOperations.GetOrder(id);
            return Ok(result);
        }

        
        [HttpPut]
        public IActionResult Edit([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.Edit(model);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //var delete = _orderOperations.GetOrder(id);
            //if (delete == null)
            //{
            //    return NotFound();
            //}
            await _orderOperations.Delete(id);
            return NoContent();


        }
    }
}
