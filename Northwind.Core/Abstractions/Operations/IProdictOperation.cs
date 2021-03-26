using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IProdictOperation
    {
        IEnumerable<ProductViewModel> GetProduct();
        IEnumerable<MyViewQuery> GetCatecoresProduct();
    }
}
