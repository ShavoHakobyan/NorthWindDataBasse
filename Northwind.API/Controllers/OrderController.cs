using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Core.BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Northwind.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;

using Northwind.Core.Entities;


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


        [HttpGet("Highfreight")]
        public IActionResult GetQuery_26()
        {
            var result = _orderOperations.GetHighfreight_25();
            return Ok(result);
        }

        [HttpGet("Highfreight_1996")]
        public IActionResult GetQuery_25()
        {
            var result = _orderOperations.GetHighfreight1996();
            return Ok(result);
        }
        [HttpGet("MonthEndOrders")]
        public IActionResult MonthEndOrders()
        {
            var result = _orderOperations.GetMonthendorders();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add([FromBody] OrderRegistrPostMode model)
        {
            if (ModelState.IsValid)
            {
                _orderOperations.Add(model);
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit([FromBody] OrderViewModel model)
        {
            var res = _orderOperations.Edit(model);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _orderOperations.Remove(id);
            return Ok();
        }

    }
}
