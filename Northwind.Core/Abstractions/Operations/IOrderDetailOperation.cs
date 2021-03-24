using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IOrderDetailOperation
    {
        IEnumerable<OrderDetailViewModel> GetOrderDetall();
    }
}
