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

        public IEnumerable<Customer31> GetCustomer31()
        {
            //31
            var customerIds = (from order in Context.Orders
                               where order.EmployeeId == 4
                               select order.CustomerId).ToList();
            var query = from customer in Context.Customers
                        where !customerIds.Contains(customer.CustomerId)
                        select new Customer31
                        {
                            CustomerId = customer.CustomerId,
                        };
            return query.ToList();
        }

        public IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions()
        {
            // num_24
            var query = from customer in Context.Customers
                        orderby customer.Region, customer.CustomerId
                        select new CustomerListbyRegion
                        {
                            CustomerId = customer.CustomerId,
                            CompanyName = customer.CompanyName,
                            Region = customer.Region
                        };
            return query.ToList();
        }

        public IEnumerable<CustomerswithOrders> GetCustomerswithnoorders()
        {
            // Num_30
            var query = from customer in Context.Customers
                        join order in Context.Orders
                            on customer.CustomerId equals order.CustomerId into g
                        from or in g.DefaultIfEmpty()
                        where or.CustomerId == null
                        select new CustomerswithOrders
                        {
                            Cutomers_Customerid = customer.CustomerId,
                            Orders_Customerid = or.CustomerId
                        };
            return query.ToList();
        }

        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            // Number 32
            var query = (from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year == 1998
                         join orddet in Context.OrderDetals on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice) > 10000
                         select new HighValueCustomers
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             OrderId = g.Key.OrderId,
                             OrderIdTotalOrderAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                         }).OrderByDescending(x => x.OrderIdTotalOrderAmount);
            return query.ToList();
        }

        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {
            // num_21
            var query = (from customer in Context.Customers
                         group customer by new { customer.City, customer.Country } into g
                         select new TotalCustomers
                         {
                             Country = g.Key.Country,
                             City = g.Key.City,
                             Totalcustomers = g.Count()
                         }).OrderByDescending(x => x.Totalcustomers);
            return query.ToList();
        }

        public IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders()
        {
            // Number 33
            var query = (from customer in Context.Customers
                         join order in Context.Orders on customer.CustomerId equals order.CustomerId
                         where order.OrderDate.Value.Year >= 1998
                         join orddet in Context.OrderDetals on order.OrderId equals orddet.OrderId
                         group orddet by new { customer.CustomerId, customer.CompanyName, order.OrderId } into g
                         where g.Sum(x => x.Quantity * x.UnitPrice) >= 15000
                         select new HighValueCustomers
                         {
                             CompanyName = g.Key.CompanyName,
                             CustomerId = g.Key.CustomerId,
                             OrderIdTotalOrderAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                         }).OrderByDescending(x => x.OrderIdTotalOrderAmount);
            return query.ToList();
        }
    }
}
