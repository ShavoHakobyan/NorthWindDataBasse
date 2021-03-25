using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.BusinessModels;

namespace Northwind.BLL.Operations
{
    public class CustomerOperation : ICustomerOperation
    {

        private readonly IRepositoryManager _customerRepository;

        private readonly ILogger<CustomerOperation> _logger;
        public CustomerOperation(IRepositoryManager customerRepository, ILogger<CustomerOperation> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        public IEnumerable<CustomerViewModel> GetCustomer()
        {
            var data = _customerRepository.Customers.GetAll();

            var result = data.Select(x => new CustomerViewModel
            {
               Address = x.Address,
               City  = x.City,
               CompanyName = x.CompanyName,
               ContactName = x.ContactName,
               ContactTitle = x.ContactTitle,
               CustomerId = x.CustomerId
            });
            return result;
        }

        public IEnumerable<Customer31> GetCustomer31()
        {
            return _customerRepository.Customers.GetCustomer31();
        }
    }
}
