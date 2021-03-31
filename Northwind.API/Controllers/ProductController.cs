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
        //[HttpPost]
        //public IActionResult Post([FromBody] ProductRegistrPostModel model)
        //{
        //    if (ModelState.IsValid)
        //        _productOperations.Add(model);
        //    else
        //        return BadRequest("Not all parameters have filled");

        //    return Created("", model);
        //}
        [HttpPut]
        public IActionResult Edit([FromBody] ProductViewModel model)
        {
            var res = _productOperations.Edit(model);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
           _productOperations.Remove(id);
            return Ok();
        }
    }
}
