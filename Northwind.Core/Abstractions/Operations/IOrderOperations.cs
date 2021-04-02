using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using System.Threading.Tasks;
using Northwind.Core.BusinessModels.MyListModel;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IOrderOperations
    {


        IEnumerable<InventoryListModel> GetInventoryList();
        IEnumerable<OrderViewModel> GetOrders();
        OrderViewModel GetOrder(int id);

        IEnumerable<HighFreightOrders> GetHighfreight_25();
        IEnumerable<HighFreightOrders> GetHighfreight1996();
       

        Order Edit(OrderViewModel model);
        public void Add(OrderRegistrPostMode model);
        Task Remove(int id);

    }
}
