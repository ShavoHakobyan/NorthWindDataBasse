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
    public class ProductController : ControllerBase
    {
        private readonly IProdictOperation _productOperations;

        public ProductController(IProdictOperation productOperations)
        {
            _productOperations = productOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _productOperations.GetProduct();
            return Ok(result);
        }

        [HttpGet("CategProduct")]
        public IActionResult GetCatecoresProduct()
        {
            var result = _productOperations.GetCatecoresProduct();
            return Ok(result);
        }
    }
}
