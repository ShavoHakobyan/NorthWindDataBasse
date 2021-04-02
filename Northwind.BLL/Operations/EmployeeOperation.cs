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

using Northwind.Core.Execption;

namespace Northwind.BLL.Operations
{
    public class EmployeeOperation : IEmployeeOperation
    {
        private readonly IRepositoryManager _employeeRepository;

        private readonly ILogger<EmployeeOperation> _logger;
        public EmployeeOperation(IRepositoryManager employeeRepository, ILogger<EmployeeOperation> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public void Add(EmployeeRegisterPostModel model)
        {
            _employeeRepository.Employee.Add(model);
            _employeeRepository.SaveChanges();
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

        public IEnumerable<EmployeeViewModel> GetModel()
        {
            return _employeeRepository.Employee.GetModel();
        }

        public Employee Edit(ChangeEmployeeModel model)
        {
            _logger.LogInformation("OrderOperations --- Edit method started");
            var emoloe = _employeeRepository.Employee.Get(model.EmployeeId) ?? throw new LogicExecption("Wrong Emploe Id");
            if (emoloe != null)
            {
                emoloe.EmployeeId = emoloe.EmployeeId;
                emoloe.FirstName = model.FirstName;
                emoloe.LastName = model.LastName;
                emoloe.BirthDate = model.BirthDate;
                emoloe.City = model.City;
                emoloe.Country = model.Country;
            }


            _employeeRepository.Employee.Update(emoloe);
            _employeeRepository.SaveChanges();
            _logger.LogInformation("OrderOperations --- Edit method finished");
            

            return emoloe;
            
        }

        public async Task Remove(int id)
        {
            var emploe = _employeeRepository.Employee.Get(id) ?? throw new LogicExecption("Wrong Employee Id");
            _employeeRepository.Employee.Remove(emploe);
           await _employeeRepository.SaveChangesAsync();
            
        }

        public EmployeeViewModel GetEmploe(int id)
        {
            var emploe = _employeeRepository.Employee.Get(id) ?? throw new LogicExecption("Wrong Employee Id");

            return new EmployeeViewModel
            {
                EmployeeId = emploe.EmployeeId,
                Address = emploe.Address,
                BirthDate = emploe.BirthDate,
                City = emploe.City,
                FirstName = emploe.FirstName,
                HireDate = emploe.HireDate,
                LastName = emploe.LastName,
                Title = emploe.Title,
                TitleOfCourtesy = emploe.TitleOfCourtesy
            };
            
        }
    }
}
