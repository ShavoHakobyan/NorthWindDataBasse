using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Repositories
{
    public  interface ICustomerRepository: IRepositoryBase<Customer>
    {
        IEnumerable<Customer31> GetCustomer31();
    }
}
