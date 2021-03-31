using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.BusinessModels;

using Northwind.Core.Entities;
using Northwind.Core.Execption;
using System.Threading.Tasks;


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

        public void Add(CustomerRegistrPostModel model)
        {
            var modelCheck = _customerRepository.Customers.GetSingle(u => u.CustomerId == model.CustomerId);
            if (modelCheck == null)
            {
                _customerRepository.Customers.Add(model);
                _customerRepository.SaveChanges();
            }
            else
            {
                throw new LogicExecption("There is already customer with that Id");
            }
        }

        public Customer Edit(ChangeCustomerModel model)
        {
            _logger.LogInformation("OrderOperations --- Edit method started");
            var customer = _customerRepository.Customers.GetSingle(u => u.CustomerId == model.CustomerId)
                ?? throw new LogicExecption("Wrong customerId");
            if (customer != null)
            {
                customer.CustomerId = customer.CustomerId;
                customer.ContactName = model.ContactName;
                customer.ContactName = model.ContactName;
                customer.ContactTitle = model.ContactTitle;
                customer.City = model.City;
                customer.Country = model.Country;
            }

            _customerRepository.Customers.Update(customer);
            _customerRepository.SaveChanges();
            _logger.LogInformation("OrderOperations --- Edit method finished");


            return customer;
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

        public IEnumerable<CustomerViewModel> GetModel24()
        {
            return _customerRepository.Customers.GetModel24();
        }

        public async Task Remove(string id)
        {
            var customer = _customerRepository.Customers.GetSingle(u => u.CustomerId == id)
                ?? throw new LogicExecption("Wrong customerId"); ;
            _customerRepository.Customers.Remove(customer);
            await _customerRepository.SaveChangesAsync();
        }

     
    }
}
