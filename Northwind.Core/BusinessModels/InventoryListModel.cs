using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class InventoryListModel
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }

       
        public string CategoryName { get; set; }

        public int ProductId { get; set; }

        public int TutoryalCount { get; set; }
       
    }
}
