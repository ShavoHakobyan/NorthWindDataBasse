using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;

namespace Northwind.Core.Abstractions.Repositories
{
    public interface IProductRespository : IRepositoryBase<Product>
    {
        // IEnumerable<InventoryListModel> GetCatecoresProduct();
        IEnumerable<MyViewQuery> GetCatecoresProduct();
        void Add(ProductRegistrPostModel model);
       
    }
}
