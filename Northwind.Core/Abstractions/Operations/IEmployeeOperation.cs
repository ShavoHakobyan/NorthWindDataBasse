using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.BusinessModels;

using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IEmployeeOperation
    {
        IEnumerable<EmployeeViewModel> GetEmployes();
        IEnumerable<EmployeeViewModel> GetModel();
        //
        public void Add(EmployeeRegisterPostModel model);
        Employee Edit(ChangeEmployeeModel model);
        Task Remove(int id);


    }
}
