using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Operations;
using System.Net.Http;

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
       
    }
}
