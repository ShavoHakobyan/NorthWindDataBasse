using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepositor
    {
        public SupplierRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
