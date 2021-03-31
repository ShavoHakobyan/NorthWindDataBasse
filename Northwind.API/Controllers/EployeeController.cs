using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;
using System.Net.Http;
using Northwind.Core.BusinessModels;

namespace Northwind.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EployeeController :ControllerBase
    {
        private readonly IEmployeeOperation _employeeOperations;

        public EployeeController(IEmployeeOperation employeeOperations)
        {
            _employeeOperations = employeeOperations;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeOperations.GetEmployes();
            return Ok(result);
        }
        
        [HttpGet("GetModel")]
        public IActionResult GetModel()
        {
            var result = _employeeOperations.GetModel();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeRegisterPostModel model)
        {
            if (ModelState.IsValid)
                _employeeOperations.Add(model);
            else
                return BadRequest("Not all parameters have filled");

            return Created("", model);
        }
        [HttpPut]
        public IActionResult Edit([FromBody] ChangeEmployeeModel model)
        {
            var res = _employeeOperations.Edit(model);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _employeeOperations.Remove(id);
            return Ok();
        }
    }
}
