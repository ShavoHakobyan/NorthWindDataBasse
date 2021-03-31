﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.BusinessModels;

using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Operations
{
    public interface ICustomerOperation
    {
        IEnumerable<CustomerViewModel> GetCustomer();
        //IEnumerable<Customer31> GetCustomer31();
        IEnumerable<CustomerViewModel> GetModel24();

        public void Add(CustomerRegistrPostModel model);
        Customer Edit(ChangeCustomerModel model);
        Task Remove(string id);
    }
}
