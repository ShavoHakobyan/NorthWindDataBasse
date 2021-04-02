using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels.MyListModel
{
    public class LateOrdersWhichEmployees
    {
        public int? EmployeeId { get; set; }
        public string LastName { get; set; }
        public int TotalLateOrders { get; set; }
    }
}
