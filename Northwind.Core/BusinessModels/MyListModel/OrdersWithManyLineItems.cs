using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels.MyListModel
{
    public class OrdersWithManyLineItems
    {
        public int OrderId { get; set; }
        public int TotalOrderDetails { get; set; }
    }
}
