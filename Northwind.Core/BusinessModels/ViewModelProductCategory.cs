using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class ViewModelProductCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public int NumOfProductsInThisCategory { get; set; }
    }
}
