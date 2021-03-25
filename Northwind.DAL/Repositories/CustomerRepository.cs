using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;
using System.Linq;
namespace Northwind.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Customer31> GetCustomer31()
        {
            var query = (from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.CustomerId == null && order.EmployeeId == 4
                         select new Customer31
                         {
                             CustomerId = customer.CustomerId,
                             id = order.CustomerId
                         }).ToList();
            return query;
        }

    }
}
