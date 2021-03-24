using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;

namespace Northwind.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

       
    }
}
