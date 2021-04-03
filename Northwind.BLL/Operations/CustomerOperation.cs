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

        public IEnumerable<Customer31> GetCustomer31()
        {
            return _customerRepository.Customers.GetCustomer31();
        }

        public CustomerViewModel GetCustomerID(string customer)
        {
            var customerId = _customerRepository.Customers.GetSingle(u => u.CustomerId == customer)
               ?? throw new LogicExecption("Wrong customerId");
            return new CustomerViewModel
            {
                Address = customerId.Address,
                City = customerId.City,
                CompanyName = customerId.CompanyName,
                ContactName = customerId.ContactName,
                ContactTitle = customerId.ContactTitle,
                CustomerId = customerId.CustomerId,
                Region = customerId.Region
            };
        }

        public IEnumerable<CustomerListbyRegion> GetCustomerlistbyregions()
        {
            _logger.LogInformation("CustomerOperation --- Number 24");
            return _customerRepository.Customers.GetCustomerlistbyregions();
        }

        public IEnumerable<CustomerswithOrders> GetCustomerswithnoorders()
        {
            _logger.LogInformation("CustomersOperation --- Number 30");
            return _customerRepository.Customers.GetCustomerswithnoorders();
        }

        public IEnumerable<HighValueCustomers> GetHighvaluecustomers()
        {
            _logger.LogInformation("CustomersOperation --- Number 32");
            return _customerRepository.Customers.GetHighvaluecustomers();
        }

        
        public IEnumerable<TotalCustomers> GetTotalCustomers()
        {

           _logger.LogInformation("CustomerOperation --- Number 21");
            return _customerRepository.Customers.GetTotalCustomers();
        }

        public IEnumerable<HighValueCustomers> Highvaluecustomerstotalorders()
        {
            _logger.LogInformation("CustomersOperation --- Number 33");
            return _customerRepository.Customers.Highvaluecustomerstotalorders();
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
