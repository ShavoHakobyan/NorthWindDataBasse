using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.BusinessModels;

namespace Northwind.BLL.Operations
{
    public class OrderDetailOperation : IOrderDetailOperation
    {
        private readonly IRepositoryManager _orderRepository;

        // private readonly ILogger<OrderOperations> _logger;
        public OrderDetailOperation(IRepositoryManager orderRepository)
        {
            _orderRepository = orderRepository;
            // _logger = logger;
        }

        public IEnumerable<OrderDetailViewModel> GetOrderDetall()
        {
            var data = _orderRepository.OrderDetail.GetAll();

            var result = data.Select(x => new OrderDetailViewModel
            {
                OrderId = x.OrderId,
                ProductId = x.OrderId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            });
            return result;
        }

    }
}
