using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
