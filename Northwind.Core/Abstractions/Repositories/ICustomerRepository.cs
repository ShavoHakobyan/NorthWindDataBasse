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
       // IEnumerable<CustomerViewModel> GetModel24();
        void Add(CustomerRegistrPostModel model);

        IEnumerable<CustomerswithOrders> GetCustomerswithnoorders();
        IEnumerable<TotalCustomers> GetTotalCustomers();
        IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions();
        IEnumerable<HighValueCustomers> GetHighvaluecustomers();
        IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders();
    }
}
