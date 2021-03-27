using Microsoft.Extensions.Logging;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Execption;
using System.Collections.Generic;
using System.Linq;
using Northwind.Core.Abstractions;
using Northwind.Core.BusinessModels;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.Entities;
using System.Threading.Tasks;


namespace Northwind.BLL.Operations
{
    public class OrderOperations : IOrderOperations
    {
        private readonly IRepositoryManager _orderRepository;

        private readonly ILogger<OrderOperations> _logger;
        public OrderOperations(IRepositoryManager orderRepository, ILogger<OrderOperations> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public Order Add(OrderViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
           
            var order =  _orderRepository.Orders.Get(id);
            _orderRepository.Orders.Remove(order);
            await _orderRepository.SaveChangesAsync();
        }

        public Order Edit(OrderViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Edit method started");
            Order order = new Order
            {
                OrderId = model.OrderId
            };
            order.CustomerId = model.CustomerId;
            order.EmployeeId = model.EmployeeId;
            order.ShipAddress = model.ShipAddress;
            order.ShipName = model.ShipName;

            _orderRepository.Orders.Update(order);
            _orderRepository.SaveChanges();
            _logger.LogInformation("OrderOperations --- Edit method finished");
            return order;
        }

        public IEnumerable<InventoryListModel> GetInventoryList()
        {
            return _orderRepository.Orders.GetInventoryList();
        }

        public OrderViewModel GetOrder(int id)
        {
            // Log.Logger.Information("OrderOperations --- GetOrder method started");
            _logger.LogInformation("OrderOperations --- GetOrder method started");
            var order = _orderRepository.Orders.Get(id) ?? throw new LogicExecption("Wrong Order Id");


            //Log.Logger.Information("OrderOperations --- GetOrder method finished");
            _logger.LogInformation("OrderOperations --- GetOrder method finished");
            return new OrderViewModel
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderId = order.OrderId,
                ShipAddress = order.ShipAddress,
                ShipName = order.ShipName
            };
        }

       
        public IEnumerable<OrderViewModel> GetOrders()
        {
            var data = _orderRepository.Orders.GetAll();

            var result = data.Select(x => new OrderViewModel
            {
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderId = x.OrderId,
                ShipAddress = x.ShipAddress,
                ShipName = x.ShipName
            });
            return result;
        }

       
    }
}
