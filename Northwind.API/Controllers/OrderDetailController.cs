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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailOperation _orderDtOperations;

        public OrderDetailController(IOrderDetailOperation orderDtOperations)
        {
            _orderDtOperations = orderDtOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderDtOperations.GetOrderDetall();
            return Ok(result);
        }
    }
}
