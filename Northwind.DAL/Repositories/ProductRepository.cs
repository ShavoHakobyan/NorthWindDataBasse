using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;

namespace Northwind.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRespository
    {
        public ProductRepository(NorthwindContext dbContext)
           : base(dbContext)
        {
        }

     

        public IEnumerable<InventoryListModel> GetCatecoresProduct()
        {

            var VMCategory = from p in Context.Products
                             join categ in Context.Categories on p.CategoryId equals categ.CategoryId
                             group  categ.CategoryName by p into x
                             orderby x
                             select new InventoryListModel
                             {
                                
                                 ProductName= x.Key.ProductName,
                                 ProductId = x.Key.ProductId
                                 
                             };
            return VMCategory.ToList(); 
          
        }

        
    }
}
