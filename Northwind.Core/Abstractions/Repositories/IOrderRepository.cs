using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

namespace Northwind.Core.Abstractions.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IEnumerable<InventoryListModel> GetInventoryList();
    }
}
