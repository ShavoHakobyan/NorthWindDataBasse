using Northwind.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions
{
    public interface IRepositoryManager
    {
        public IOrderRepository Orders { get; }
        public ICustomerRepository Customers { get; }
        public IProductRespository Product { get; }
        public IEmployeeRepository Employee { get; }
        public IUserRepository Users { get; }

        public ISupplierRepositor supplier { get; }
        public ICategoryRepository Categories { get; }

        void SaveChanges();
        Task SaveChangesAsync();
      
    }
}
