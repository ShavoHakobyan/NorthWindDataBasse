using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;

namespace Northwind.DAL.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetalsRepository
    {
        public OrderDetailRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Add(OrderDetailPostModel model)
        {
            Context.OrderDetails.Add(new OrderDetail
            {
                Discount = model.Discount,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice

            });
        }
    }
 
}
