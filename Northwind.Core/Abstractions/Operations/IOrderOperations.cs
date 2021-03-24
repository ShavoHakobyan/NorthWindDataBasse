using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IOrderOperations
    {


        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int id);
    }
}
