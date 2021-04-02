using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Northwind.Core.BusinessModels;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Operations;

using Northwind.Core.Entities;
using Northwind.Core.Execption;

namespace Northwind.BLL.Operations
{
    public class OrderDetailOperation : IOrderDetailOperation
    {
        private readonly IRepositoryManager _orderRepository;

         private readonly ILogger<OrderOperations> _logger;
        public OrderDetailOperation(IRepositoryManager orderRepository, ILogger<OrderOperations> logger)
        {
            _orderRepository = orderRepository;
             _logger = logger;
        }

        public void Add(OrderDetailPostModel model)
        {
            var product = _orderRepository.Product.GetSingle(u => u.ProductId == model.ProductId)
            ?? throw new LogicExecption("Wrong productId");

            var order = _orderRepository.Orders.GetSingle(u => u.OrderId == model.OrderId)
              ??  throw new LogicExecption("Wrong OrderId");
            _orderRepository.OrderDetail.Add(model);
           _orderRepository.SaveChanges();
        }

        public OrderDetail Edit(OrderDetailViewModel model)
        {
            _logger.LogInformation("OrderDetailsOparation --- Edit method started");
            var product = _orderRepository.Product.Get(model.ProductId) ?? throw new LogicExecption("Wrong Order Id");
            var order = _orderRepository.Orders.GetSingle(u => u.OrderId == model.OrderId)
             ?? throw new LogicExecption("Wrong OrderId");

            var orderdt = _orderRepository.OrderDetail.Get(model.OrderId);
            orderdt.OrderId = orderdt.OrderId;
            orderdt.ProductId = orderdt.ProductId;
            orderdt.Discount = model.Discount;
            orderdt.Quantity = model.Quantity;
            orderdt.UnitPrice = model.UnitPrice;

            _orderRepository.OrderDetail.Update(orderdt);
            _orderRepository.SaveChanges();

            _logger.LogInformation("OrderDetailsOparation --- Edit method finished");

            return orderdt;
        }

        public IEnumerable<OrderDetailViewModel> GetOrderDetall()
        {
            var data = _orderRepository.OrderDetail.GetAll();

            var result = (from od in data
                       select new OrderDetailViewModel
                       {
                           Discount = od.Discount,
                           OrderId = od.OrderId,
                           ProductId = od.ProductId,
                           Quantity = od.Quantity,
                           UnitPrice = od.UnitPrice

                       }).ToList();
            return result;
        }

    }
}
