using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using Northwind.Core.BusinessModels.MyListModel;

namespace Northwind.Core.Abstractions.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<InventoryListModel> GetInventoryList();
        void Add(OrderRegistrPostMode model);
        
        IEnumerable<HighFreightOrders> GetHighfreight_25();
        IEnumerable<HighFreightOrders> GetHighfreight1996();
       
    }
}
