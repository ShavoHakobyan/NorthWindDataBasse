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

        public void Add(CustomerRegistrPostModel model)
        {
            Context.Customers.Add(new Customer
            {
                CustomerId = model.CustomerId,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Region = model.Region
            });
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
