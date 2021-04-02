using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels.MyListModel
{
    public class LateOrders
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
