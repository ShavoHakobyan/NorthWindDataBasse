using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using System.Threading.Tasks;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IOrderOperations
    {


        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int id);

       // Order Remove(int id);
        Order Edit(OrderViewModel model);
        Order Add(OrderViewModel model);

        Task Delete(int id);

    }
}
