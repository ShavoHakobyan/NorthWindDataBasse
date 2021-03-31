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

        public void Add(ProductRegistrPostModel model)
        {
            Context.Products.Add(new Product
            {
               
                CategoryId = model.CategoryId,
                Discontinued = model.Discontinued,
               
                UnitsOnOrder = model.UnitsOnOrder,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                SupplierId = model.SupplierId,
                QuantityPerUnit = model.QuantityPerUnit

                

            });
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
