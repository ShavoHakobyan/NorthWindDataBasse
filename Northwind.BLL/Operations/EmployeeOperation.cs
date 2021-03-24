using Microsoft.Extensions.Logging;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.Abstractions;
using Northwind.Core.BusinessModels;
using Northwind.Core.Abstractions.Operations;

namespace Northwind.BLL.Operations
{
    public class EmployeeOperation : IEmployeeOperation
    {
        private readonly IRepositoryManager _employeeRepository;

       // private readonly ILogger<EmployeeOperation> _logger;
        public EmployeeOperation(IRepositoryManager employeeRepository)//, ILogger<EmployeeOperation> logger)
        {
            _employeeRepository = employeeRepository;
            //_logger = logger;
        }



        public IEnumerable<EmployeeViewModel> GetEmployes()
        {
            var data = _employeeRepository.Employee.GetAll();

            var result = data.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy,
                Address = x.Address,
                HireDate = x.HireDate,
                BirthDate = x.BirthDate,
                City = x.City
            });
            return result;
        }


    }
}
