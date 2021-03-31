using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using System.Linq;


namespace Northwind.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext dbContext) : base(dbContext)
        {

        }

        public void Add(EmployeeRegisterPostModel model)
        {
            Context.Employees.Add(new Employee
            {
                BirthDate = model.BirthDate,
                City = model.City,
                Country = model.Country,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Region = model.Region,
                Title = model.Title,
                TitleOfCourtesy = model.TitleOfCourtesy
            });
        }

        public IEnumerable<EmployeeViewModel> GetModel()
        {
            var query = (from e in Context.Employees
                            join or in Context.Orders on e.EmployeeId equals or.EmployeeId
                            join ord in Context.OrderDetails on or.OrderId equals ord.OrderId
                            group e by new
                            {
                                e.EmployeeId,
                                e.LastName,
                                e.FirstName,
                                amount = e.Orders.Count
                            } into c
                            orderby c.Key.amount descending
                            select new EmployeeViewModel
                            {
                                FirstName = c.Key.FirstName,
                                LastName = c.Key.LastName,
                                EmployeeId = c.Key.EmployeeId
                            }).Take(10);
            return query.ToList();
        }

    }
}


