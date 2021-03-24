﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
