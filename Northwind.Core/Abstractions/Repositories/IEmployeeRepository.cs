using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Abstractions.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        public IEnumerable<EmployeeViewModel> GetModel();
    }
}
