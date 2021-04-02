using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class MonthEndOrders
    {
        public int? EmployeeID { get; set; }
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
