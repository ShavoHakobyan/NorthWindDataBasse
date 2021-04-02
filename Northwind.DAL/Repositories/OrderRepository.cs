using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using Northwind.Core.BusinessModels.MyListModel;

namespace Northwind.DAL.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext dbContext)
            : base(dbContext)
        {
        }

        public void Add(OrderRegistrPostMode model)
        {
            Context.Orders.Add(new Order
            {
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                Freight = model.Freight,
                ShipAddress = model.ShipAddress,
                ShipName = model.ShipName,
                ShipCountry = model.ShipCountry,
                ShipCity = model.ShipCity
            });
        }

        public IEnumerable<HighFreightOrders> GetHighfreight1996()
        {
            // N_26
            var query = (from order in Context.Orders
                         where order.OrderDate.Value.Year == 1997
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }

        

        public IEnumerable<HighFreightOrders> GetHighfreight_25()
        {
            // N_25
            var query = (from order in Context.Orders
                         group order by order.ShipCountry into g
                         select new HighFreightOrders
                         {
                             ShipCountry = g.Key,
                             AverageFreight = g.Average(x => x.Freight)
                         }).OrderByDescending(x => x.AverageFreight).Take(3);
            return query.ToList();
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            var query = from order in Context.Orders
                        join employee in Context.Employees on order.EmployeeId equals employee.EmployeeId
                        join orderDetail in Context.OrderDetals on order.OrderId equals orderDetail.OrderId
                        join product in Context.Products on orderDetail.ProductId equals product.ProductId
                        orderby order.OrderId, product.ProductId
                        select new InventoryListModel
                        {
                            EmployeeId = employee.EmployeeId,
                            LastName = employee.LastName,
                            OrderId = order.OrderId,
                            ProductName = product.ProductName,
                            Quantity = orderDetail.Quantity
                        };

            return query.ToList();
        }

        public IEnumerable<MonthEndOrders> GetMonthendorders()
        {
            // Number 35
            var query = from order in Context.Orders
                        where order.OrderDate.HasValue &&
                        order.OrderDate.Value.AddDays(1).Month > order.OrderDate.Value.Month
                        orderby order.EmployeeId, order.OrderId
                        select new MonthEndOrders
                        {
                            OrderId = order.OrderId,
                            EmployeeID = order.EmployeeId,
                            OrderDate = order.OrderDate
                        };
            return query.ToList();
        }


       



    }
}
