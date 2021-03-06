using Northwind.Core.BusinessModels;
using Northwind.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;

namespace Northwind.DAL
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly NorthwindContext _dbContext;
        // private readonly IServiceProvider _serviceProvider;

        public RepositoryManager(NorthwindContext dbContext/*, IServiceProvider serviceProvider*/)
        {
            _dbContext = dbContext;
            //    _serviceProvider = serviceProvider;
        }

       

        private IOrderRepository _orders;
        private ICustomerRepository _customer;
        private IProductRespository _product;
        private IEmployeeRepository _employeel;
       
        private IUserRepository _users;

        public IOrderRepository Orders => _orders ?? (_orders = new OrderRepository(_dbContext));
        public IProductRespository Product => _product ?? (_product = new ProductRepository(_dbContext));
        public IEmployeeRepository Employee => _employeel ?? (_employeel = new EmployeeRepository(_dbContext));
        public ICustomerRepository Customers => _customer ?? (_customer = new CustomerRepository(_dbContext));
       
        public IUserRepository Users => _users ?? (_users = new UserRepository(_dbContext));

        private ICategoryRepository _category;
        public ICategoryRepository Categories => _category ?? (_category = new CategoryRepository(_dbContext));
        private ISupplierRepositor _supplier;
        public ISupplierRepositor supplier => _supplier ?? (_supplier = new SupplierRepository(_dbContext));

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

       
    }
}
