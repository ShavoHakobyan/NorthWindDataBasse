﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class ChangeEmployeeModel
    {
        
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
