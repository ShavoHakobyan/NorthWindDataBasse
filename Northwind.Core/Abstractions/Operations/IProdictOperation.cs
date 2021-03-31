using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Operations
{
    public interface IProdictOperation
    {
        IEnumerable<ProductViewModel> GetProduct();
        IEnumerable<MyViewQuery> GetCatecoresProduct();
        Task Remove(int id);
        public void Add(ProductRegistrPostModel model);
        Product Edit(ProductViewModel model);
       
    }
}
