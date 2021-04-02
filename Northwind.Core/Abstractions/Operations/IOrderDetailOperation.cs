using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IOrderDetailOperation
    {
        public void Add(OrderDetailPostModel model);
        OrderDetail Edit(OrderDetailViewModel model);
        public IEnumerable<OrderDetailViewModel> GetOrderDetall();
    }
}
