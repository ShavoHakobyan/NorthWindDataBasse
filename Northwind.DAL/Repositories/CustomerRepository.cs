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
       
        public IEnumerable<CustomerViewModel> GetModel24()
        {
            var Query = from c in Context.Customers
                        where c.Region !=null
                     orderby c.Region, c.CustomerId
                    
                        select new CustomerViewModel
                        {
                            CustomerId = c.CustomerId,
                            CompanyName = c.CompanyName,
                            Region = c.Region
                        };
            return Query.ToList();
        }

      

    }
}
