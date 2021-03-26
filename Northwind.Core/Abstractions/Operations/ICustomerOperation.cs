using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

namespace Northwind.Core.Abstractions.Operations
{
    public interface ICustomerOperation
    {
        IEnumerable<CustomerViewModel> GetCustomer();
        //IEnumerable<Customer31> GetCustomer31();
        IEnumerable<CustomerViewModel> GetModel24();
    }
}
