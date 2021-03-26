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
     
        public IEnumerable<MyViewQuery> GetCatecoresProduct()
        {
            var VMCategory = from p in Context.Products
                             where !(p.UnitsInStock + p.UnitsOnOrder > p.ReorderLevel || !p.Discontinued)
                             orderby p.ProductId
                             select new MyViewQuery
                             {
                                 ProductName= p.ProductName,
                                 ProductId = p.ProductId,
                                 UnitsInStock = p.UnitsInStock,
                                 ReorderLevel = p.ReorderLevel,
                                 Discontinued = p.Discontinued
                             };
            return VMCategory.ToList(); 
          
        }

       
    }
}
