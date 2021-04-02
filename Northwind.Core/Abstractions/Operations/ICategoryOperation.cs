using Northwind.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Abstractions.Operations
{
    public interface ICategoryOperation
    {
        IEnumerable<CatrgoryViewModel> GetCategory();
    }
}
